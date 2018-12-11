using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace LIFX.pages
{
    public class GetLifx
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Body { get; set; }
        public string URL { get; set; }
    }

    public class LifxAPICallerObject
    {
        public string Power { get; set; }
        public string Color { get; set; }
        public double Brightness { get; set; }
        public double Duration { get; set; }
    }

    public class RestService
    {
        //HttpClient client;
        GetLifx lifx;
        internal const string USERNAME = "";
        internal const string PASSWORD = "";
        internal const string CONTENT_TYPE = "application/json";

        public RestService()
        {
            lifx = new GetLifx
            {
                UserName = USERNAME,
                Password = PASSWORD
            };
        }

        private string GetAuthorizationHeader()
        {
            var authData = string.Format("{0}:{1}", lifx.UserName, lifx.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            return authHeaderValue;
        }

        private void MakePostApiCall(string url, JObject jsonObject)
        {
            var authorizationHeaderValue = GetAuthorizationHeader();

            HttpClient oHttpClient = new HttpClient();
            oHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeaderValue);

            var oTaskPostAsync = oHttpClient.PostAsync(url, new StringContent(jsonObject.ToString(), Encoding.UTF8, CONTENT_TYPE));
            oTaskPostAsync.ContinueWith((oHttpResponseMessage) =>
            {
                // caller block
                // this code won't execute until a response has been received from the Post
            });
        }

        private void MakePutApiCall(string url, JObject jsonObject)
        {
            var authorizationHeaderValue = GetAuthorizationHeader();

            HttpClient oHttpClient = new HttpClient();
            oHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeaderValue);

            var oTaskPutAsync = oHttpClient.PutAsync(url, new StringContent(jsonObject.ToString(), Encoding.UTF8, CONTENT_TYPE));
            oTaskPutAsync.ContinueWith((oHttpResponseMessage) =>
            {
                // caller block
                // this code won't execute until a response has been received from the Post
            });
        }


        // POST: https://api.lifx.com/v1/lights/group:Living Room/toggle
        //BODY: { "duration": 5.0 }
        public void ToggleLights(LifxAPICallerObject lifxAPICallerObject)
        {
            var urlValue = "https://api.lifx.com/v1/lights/group:Living Room/toggle";
            var jsonObject = new JObject
            {
                { "duration", lifxAPICallerObject.Duration }
            };

            //String url, JObject jsonObject
            MakePostApiCall(urlValue, jsonObject);
        }

        //{  "power": "on", "color": "white", "brightness": 0.1, "duration": 2 }
        public void ChangeLightsColor(LifxAPICallerObject lifxAPICallerObject)
        {
            var urlValue = "https://api.lifx.com/v1/lights/group:Living Room/state";
            var jsonObject = new JObject
            {
                { "power", lifxAPICallerObject.Power },
                { "color", lifxAPICallerObject.Color },
                { "brightness", lifxAPICallerObject.Brightness },
                { "duration", lifxAPICallerObject.Duration }
            };

            //String url, JObject jsonObject
            MakePutApiCall(urlValue, jsonObject);
        }
    }

}