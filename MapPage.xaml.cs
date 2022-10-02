using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private IGeolocator locator = CrossGeolocator.Current;

        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetLocation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            locator.StopListeningAsync();
        }

        private async void GetLocation()
        {
            var status = await CheckAndRequestLocationPermission();

            if (status == PermissionStatus.Granted)
            {
                var location = await Geolocation.GetLocationAsync();

                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(new TimeSpan(0, 1, 0), 50);
                destinationMap.IsShowingUser = true;
                panToUser(location.Latitude, location.Longitude);
            }
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            panToUser(e.Position.Latitude, e.Position.Longitude);
        }

        private void panToUser(double latitude, double longitude)
        {
            MapSpan mapSpan = new MapSpan(new Xamarin.Forms.Maps.Position(latitude, longitude), 1, 1);
            destinationMap.MoveToRegion(mapSpan);
        }

        private async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
            {
                return status;
            }
            else
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                return status;
            }
        }
    }
}

// FourSquare places API key fsq3jFIsagoVnsr2JxFdfYUlHLwdeeqm2rA3CSFNrHV0Zyk=
// Client ID BLNKA2NY14AXPHNQU2XPNZOUR5QWJQQV5KLZ5GPEESHKWZBB
// Client Secret LVCL3AGZRBGOSAQPDA5COG41YWHFUOPVXRPMY2ZGIN1ICBJQ
// URL: 