using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
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