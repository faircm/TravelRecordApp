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
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Using statement, automatically closes connection after statement ends
            using (SQLiteConnection conn = new SQLiteConnection(App._databaseLocation))
            {
                //
                conn.CreateTable<Post>();

                // Retrieve table contents, put in list
                List<Post> postList = conn.Table<Post>().ToList();
                historyList.ItemsSource = postList;
            }
        }

        private void historyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Post selectedPost = (Post)historyList.SelectedItem;

            if (selectedPost != null)
            {
                Navigation.PushAsync(new TravelDetailsPage(selectedPost));
            }
        }
    }
}