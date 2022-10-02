using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using RestSharp;
using SQLite;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = VenueLogic.getVenues(position.Latitude, position.Longitude);
        }

        private void saveBtn_Clicked(object sender, EventArgs e)
        {
            Post newEntry = new Post();
            newEntry.Destination = destinationEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App._databaseLocation))
            {
                conn.CreateTable<Post>();
                if (conn.Insert(newEntry) > 0)
                {
                    DisplayAlert("Success", "Travel record added successfully", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Travel record could not be added", "Ok");
                }
            }
        }
    }
}