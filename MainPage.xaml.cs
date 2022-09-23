using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            if (emailEntry.Text.Length != 0 || passwordEntry.Text.Length != 0)
            {
                if (passwordEntry.Text.Equals("password"))
                {
                    // Open next page
                    Navigation.PushAsync(new HomePage());
                }
            }
            else
            {
                // Pop error message
            }
        }
    }
}