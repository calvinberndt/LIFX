using System;

using Xamarin.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.Net.Http;

namespace MarathonApp
{
    public partial class MainPage : ContentPage
    {
        RaceCollection RacesObject;

        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            FillPicker();
        }

        public void Race_changed(object sender, EventArgs eventArgs)
        {
            var SelectedRace = ((Picker)sender).SelectedIndex;
            var race_id = RacesObject.races[SelectedRace].id;
            var client = new HttpClient();


            client.BaseAddress = new Uri("http://itweb.fvtc.edu/wetzel/marathon/");
            var response = client.GetAsync("results/" + race_id);
            var wsJson = response.Result.Content.ReadAsStringAsync().Result;

            var ResultsObject = JsonConvert.DeserializeObject<ResultsCollection>(wsJson);
            var CellTemplate = new DataTemplate(typeof(TextCell));
            CellTemplate.SetBinding(TextCell.TextProperty, "name");
            CellTemplate.SetBinding(TextCell.DetailProperty, "detail");
            ResultsListView.ItemTemplate = CellTemplate;

            ResultsListView.ItemsSource = ResultsObject.results; //races to results??

        }

        protected void FillPicker()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://itweb.fvtc.edu/wetzel/marathon/");
            var response = client.GetAsync("races");
            var wsJson = response.Result.Content.ReadAsStringAsync().Result;

            RacesObject = JsonConvert.DeserializeObject<RaceCollection>(wsJson);
            if (RacesObject != null)
            {
                this.RacePicker.Items.Clear();
                foreach (race CurrentRace in RacesObject.races)
                {
                    RacePicker.Items.Add(CurrentRace.race_name);
                }
            }


        }
    }
}
