using System.Net.Http;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using LIFX.Controller;

namespace LIFX.pages
{
    public class RestService
    {
        public RestService()
        {
        }

        private string GetAuthorizationHeader()
        {
            var authData = string.Format("{0}:{1}", LifxStruct.USERNAME, LifxStruct.PASSWORD);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            return authHeaderValue;
        }

        public void MakePostApiCall(string url, JObject jsonObject)
        {
            var authorizationHeaderValue = GetAuthorizationHeader();

            HttpClient oHttpClient = new HttpClient();
            oHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeaderValue);

            var oTaskPostAsync = oHttpClient.PostAsync(url, new StringContent(jsonObject.ToString(), Encoding.UTF8, LifxStruct.CONTENT_TYPE));
            oTaskPostAsync.ContinueWith((oHttpResponseMessage) =>
            {
                // caller block
                // this code won't execute until a response has been received from the Post
            });
        }

        public void MakePutApiCall(string url, JObject jsonObject)
        {
            var authorizationHeaderValue = GetAuthorizationHeader();

            HttpClient oHttpClient = new HttpClient();
            oHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeaderValue);

            var oTaskPutAsync = oHttpClient.PutAsync(url, new StringContent(jsonObject.ToString(), Encoding.UTF8, LifxStruct.CONTENT_TYPE));
            oTaskPutAsync.ContinueWith((oHttpResponseMessage) =>
            {
                // caller block
                // this code won't execute until a response has been received from the Post
            });
        }
    }
}