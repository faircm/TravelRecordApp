using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TravelDetailsPage : ContentPage
    {
        private Post selectedPost;

        public TravelDetailsPage(Post selectedPost)
        {
            InitializeComponent();

            destinationId.Text = selectedPost.Id.ToString();
            destinationLabel.Text = selectedPost.Destination;
        }

        private void updateBtn_Clicked(object sender, EventArgs e)
        {
            selectedPost.Destination = destinationLabel.Text;
        }

        private void deleteBtn_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App._databaseLocation))
            {
                conn.CreateTable<Post>();
                if (conn.Delete(selectedPost) > 0)
                {
                    DisplayAlert("Success", "Travel record deleted successfully", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Travel record could not be deleted", "Ok");
                }
            }
        }
    }
}