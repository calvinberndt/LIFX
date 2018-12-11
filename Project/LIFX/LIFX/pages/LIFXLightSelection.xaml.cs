﻿using System;
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
        }

        private async void Info_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Info_Page());
        }

        void Toggle_Clicked(object sender, System.EventArgs e)
        {
            var restService = new RestService();
            var lifxAPICallerObject = new LifxAPICallerObject();

            lifxAPICallerObject.Duration = 5.0;

            restService.ToggleLights(lifxAPICallerObject);
        }

        void Red_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
        void Blue_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
