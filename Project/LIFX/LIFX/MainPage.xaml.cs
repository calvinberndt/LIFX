using System;
using LIFX.pages;
using Xamarin.Forms;
namespace LIFX
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = "Berndt Productions";
            ToolbarItem tbi = new ToolbarItem();
            tbi.Text = "App Assistant";

            tbi.Clicked += delegate {
                Navigation.PushAsync(new LIFXLightSelection());
            };
        }

        void Light_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
