using System;
using System.Collections.Generic;

using Xamarin.Forms;

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

            var restService = new RestService();
            var lifxAPICallerObject = new LifxAPICallerObject();

            lifxAPICallerObject.Duration = 5.0;

            restService.ToggleLights(lifxAPICallerObject);
        }

        private async void Info_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Info_Page());
        }
    }
}
