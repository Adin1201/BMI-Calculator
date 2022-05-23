using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MickeMuster
{
    public partial class MainPage : ContentPage
    {
        public string GPSLocation = "No GPS";
        public double GPSLocationX = 0;
        public double GPSLocationY = 0;
        public bool metric = true;
        public bool imperial = false;
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            /*try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(30)));
                }
                if (location == null)
                {
                    GPSLocation = "No GPS";         
                }
                else
                {
                    GPSLocation = $"{location.Latitude} {location.Longitude}";
                    GPSLocationX = location.Latitude;
                    GPSLocationY = location.Longitude;
                }
            }
            catch (Exception ex)
            {
                GPSLocation = "NO GPS SIGNAL";
            }
            //await DisplayAlert("Geocoding", GPSLocation, "OK");
            */

            if (String.IsNullOrEmpty(entry1.Text) || String.IsNullOrEmpty(entry2.Text) || String.IsNullOrEmpty(entry3.Text) || picker.SelectedIndex == -1)
            {
                await DisplayAlert("ERROR", "Popunite sva polja/odaberite spol.", "OK");

            }
            else
            {
                double godine = Convert.ToDouble(entry3.Text);
                double visina = 0;
                double tezina = 0;
                double bmi = 0;
                if (metric == true)
                {
                    visina = (Convert.ToDouble(entry1.Text)) / 100;
                    tezina = Convert.ToDouble(entry2.Text);
                    bmi = Math.Round(tezina / (visina * visina), 1);
                    visina *= 100;
                }
                else if (imperial == true)
                {
                    visina = (Convert.ToDouble(entry1.Text));
                    tezina = (Convert.ToDouble(entry2.Text));
                    bmi = Math.Round((tezina * 703) / (visina * visina), 1);
                    visina *= 2.5;
                    tezina /= 2.2;
                }
                Osoba o = new Osoba();
                o.tezina = tezina;
                o.visina = visina;
                o.bmi = bmi;
                o.godine = godine;
                if(picker.SelectedIndex == 0)
                {
                    o.spol = "m";
                }
                else
                {
                    o.spol = "z";
                }
                String bmitest = Convert.ToString(bmi);
                if (bmi > 30)
                {
                    var gojaznost = new Obese(o);
                    await Navigation.PushAsync(gojaznost);
                }else if(bmi < 18.5)
                {
                    var underweight = new Underweight(o);
                    await Navigation.PushAsync(underweight);
                }else if(bmi > 18.5 && bmi < 25)
                {
                    var normal = new Normal(o);
                    await Navigation.PushAsync(normal);
                }else if(bmi > 25 && bmi < 30)
                {
                    var overweight = new Overweight(o);
                    await Navigation.PushAsync(overweight);
                }
               // var tstna = new testna();
                //var secondPage = new ShowHotels(osoba);
                //   await Navigation.PushAsync(tstna);

            }

           


        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            entry1.Placeholder = "Vaša visina u centimetrima";
            entry2.Placeholder = "Vaša težina u kilogramima";
            imperial = false;
            metric = true;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            entry1.Placeholder = "Vaša visina u inčima";
            entry2.Placeholder = "Vaša težina u lbs";
            metric = false;
            imperial = true;
        }
    }
}
