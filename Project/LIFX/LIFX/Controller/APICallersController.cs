using System;
using LIFX.pages;
using Newtonsoft.Json.Linq;
using static LIFX.Controller.LifxApiCallerProperties;

namespace LIFX.Controller
{
    public class APICallersController
    {
        RestService restService;

        public APICallersController()
        {
            var props = new LifxApiCallerProperties();
            restService = new RestService();
        }

        //POST: https://api.lifx.com/v1/lights/group:Living Room/toggle
        //BODY: { "duration": 5.0 }
        public void ToggleLights(LifxAPICallerObject lifxAPICallerObject)
        {
            var urlValue = "https://api.lifx.com/v1/lights/group:Living Room/toggle";
            var jsonObject = new JObject
            {
                { "duration", lifxAPICallerObject.Duration }
            };

            restService.MakePostApiCall(urlValue, jsonObject);
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

            restService.MakePutApiCall(urlValue, jsonObject);
        }
    }
}
