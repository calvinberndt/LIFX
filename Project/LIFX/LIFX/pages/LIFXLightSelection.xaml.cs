using System;
using System.Collections.Generic;
using LIFX.Controller;
using Xamarin.Forms;
using static LIFX.Controller.LifxApiCallerProperties;

namespace LIFX.pages
{
    public partial class LIFXLightSelection : ContentPage
    {
        public LIFXLightSelection()
        {
            InitializeComponent();
            Title = "Berndt Productions";
        }

        private async void Home_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Info_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Info_Page());
        }

        void Toggle_Clicked(object sender, System.EventArgs e)
        {
            var apiCallersController = new APICallersController();

            var lifxAPICallerObject = new LifxAPICallerObject
            {
                Duration = 5.0
            };

            apiCallersController.ToggleLights(lifxAPICallerObject);
        }

        void Red_Clicked(object sender, System.EventArgs e)
        {
            //{  "power": "on", "color": "white", "brightness": 0.1, "duration": 2 }
            var apiCallersController = new APICallersController();

            var lifxAPICallerObject = new LifxAPICallerObject
            {
                Power = "on",
                Color = "red",
                Brightness = 0.8,
                Duration = 3.0
            };

            apiCallersController.ChangeLightsColor(lifxAPICallerObject);
        }

        void Blue_Clicked(object sender, System.EventArgs e)
        {
            //{  "power": "on", "color": "white", "brightness": 0.1, "duration": 2 }
            var apiCallersController = new APICallersController();

            var lifxAPICallerObject = new LifxAPICallerObject
            {
                Power = "on",
                Color = "blue",
                Brightness = 0.8,
                Duration = 3.0
            };

            apiCallersController.ChangeLightsColor(lifxAPICallerObject);
        }
    }
}
