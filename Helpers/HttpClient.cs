using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecordApp.Helpers
{
    public class HttpClient
    {
        public static HttpClient client = new HttpClient();

        private static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }