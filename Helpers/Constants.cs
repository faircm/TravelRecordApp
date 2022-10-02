using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TravelRecordApp.Helpers
{
    public class Constants
    {
        public const string PLACES_SEARCH = "https://api.foursquare.com/v3/places/search";
        public const string API_KEY = "fsq3jFIsagoVnsr2JxFdfYUlHLwdeeqm2rA3CSFNrHV0Zyk=";
        public const string CLIENT_ID = "BLNKA2NY14AXPHNQU2XPNZOUR5QWJQQV5KLZ5GPEESHKWZBB";
        public const string CLIENT_SECRET = "LVCL3AGZRBGOSAQPDA5COG41YWHFUOPVXRPMY2ZGIN1ICBJQ";
        /* private const RestClient client = new RestClient("https://api.foursquare.com/v3/places/search");
         var request = new RestRequest(Method.GET);
         request.AddHeader("accept", "application/json");
         IRestResponse response = Client.Execute(request);

         public static RestClient Client => client;*/
    }
}