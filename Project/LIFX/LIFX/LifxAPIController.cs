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
    public class RestService
    {
        //HttpClient client;
        GetLifx lifx;
        internal const string USERNAME = "cfec245f7c347678d76f83ce217908659e6dff9bb93580dc14443824e0c89b78";
        internal const string PASSWORD = "";

        public RestService()
        {
            lifx = new GetLifx
            {
                UserName = USERNAME,
                Password = PASSWORD
            };
        }

        public void MakeApiCall()
        {
            var authData = string.Format("{0}:{1}", lifx.UserName, lifx.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            //client = new HttpClient();
            HttpClient oHttpClient = new HttpClient();
            oHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

            string sUrl = "https://api.lifx.com/v1/lights/group:Living Room/toggle";
            string sContentType = "application/json";

            JObject oJsonObject = new JObject();
            //oJsonObject.Add("username", 5.0);
            oJsonObject.Add("duration", 5.0);

            var oTaskPostAsync = oHttpClient.PostAsync(sUrl, new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType));
            oTaskPostAsync.ContinueWith((oHttpResponseMessage) =>
            {
                // response of post here
            });
        }
    }

    //public class MakeLifxApiCall
    //{

    //}

    public class GetLifx
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        //public int id { get; set; }
        //public string title { get; set; }
        public string Body { get; set; }
        public string Duration { get; set; }
    }


    //public class LifxAPIController : ContentPage
    //{
    //    //https://api.lifx.com/v1/lights/group:Living Room/toggle
    //    private const string url = "https://api.lifx.com/v1/lights/group:Living Room/toggle";
    //    private HttpClient _Client = new HttpClient();
    //    private ObservableCollection<GetLifx> _getLifx;

    //    protected override async void OnAppearing()
    //    {
    //        var toggleLifxLights = new GetLifx() { 
    //            UserName = "cfec245f7c347678d76f83ce217908659e6dff9bb93580dc14443824e0c89b78",
    //            Duration = "1.0"
    //        };

    //        var content = await _Client.GetStringAsync(url);
    //        var getLifx = JsonConvert.DeserializeObject<GetLifx>(content);
    //        _getLifx = new ObservableCollection<GetLifx>((System.Collections.Generic.IEnumerable<XamarinApp3.GetLifx>)getLifx);
    //        //Get_List.ItemsSource = _get;
    //        //base.OnAppearing();
    //    }

    //    //private async void OnAdd(object sender, System.EventArgs e)
    //    //{
    //    //    var post = new Post() { title = "Title" + DateTime.Now.Ticks, body = "Body" };
    //    //    _post.Insert(0, post);
    //    //    var content = JsonConvert.SerializeObject(post);
    //    //    await _Client.PostAsync(url, new StringContent(content));
    //    //}
    //}
}