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
        }

        private async void Info_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Info_Page());
        }
    }
}
