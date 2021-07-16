using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;


namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
       
        public Page1()
        {
            InitializeComponent();
        }
        string passOnData;
        string GPSLocation="";
        double GPSLocationX=0;
        double GPSLocationY=0;

        private async void submit_Clicked(object sender, EventArgs e)
        {
            passOnData = locationEntry.Text;


            //proslijedivanje podataka na drugu stranicu
            var koordinate = new koordinate
            {
                lokacija = passOnData,
                latitude=0,
                longitude=0
                
            };

            var secondPage = new MainPage();
            secondPage.BindingContext = koordinate;
            await Navigation.PushAsync(secondPage);                                           

        }

        async private void Button_Clicked(object sender, EventArgs e)
        {

            //dohvacanje koordinata geocoding
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new  GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(30)));
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

            ///tekst na dnu prve stranice moze se izbristai
            
           _koordinate.Text = GPSLocation;

            var koordinate = new koordinate
            {
                lokacija = "",
                latitude = GPSLocationX,
                longitude = GPSLocationY

            };

            var secondPage = new MainPage();
            secondPage.BindingContext = koordinate;
            await Navigation.PushAsync(secondPage);

        }
        }
    }

