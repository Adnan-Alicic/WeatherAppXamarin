using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Net.Http;
using Xamarin.Forms;
using System.Globalization;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Xamarin.Essentials;


namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
             
        
           
        
        public MainPage()
        {
            InitializeComponent();

            
        }

        string icon;
            
        async void GetWeather(string place)
        {
            string apiKey = "54e2387eafb478641f18bf6d2c3cd429";
            string apiBase = "http://api.openweathermap.org/data/2.5/weather?q=";
            string unit = "metric";


            

            if (string.IsNullOrEmpty(place))
            {

                Lokacija.Text = "unesite ispravan grad";

                return;
            }

            if (!CrossConnectivity.Current.IsConnected)
            {
                Lokacija.Text = "unesite ispravan grad";
                return;
            }


            // Asynchronous API call using HttpClient
            string url = apiBase + place + "&appid=" + apiKey + "&units=" + unit;
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);

           

            var resultObject = JObject.Parse(result);
            string weatherDescription = resultObject["weather"][0]["description"].ToString();
            string icon = resultObject["weather"][0]["icon"].ToString();
            string temperature = resultObject["main"]["temp"].ToString();
            string placename = resultObject["name"].ToString();
            string country = resultObject["sys"]["country"].ToString();
            string minTemp = resultObject["main"]["temp_min"].ToString();
            string feelsLike = resultObject["main"]["feels_like"].ToString();
            string maxtemp = resultObject["main"]["temp_max"].ToString();
            string pressure = resultObject["main"]["pressure"].ToString();
            string humidity = resultObject["main"]["humidity"].ToString();


            weatherDescription = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(weatherDescription);

            opis.Text = weatherDescription;
            Lokacija.Text = placename + ", " + country;
            temperatura.Text = $"{temperature}° ";
            maksimalna.Text = "maximum temp - " + $"{maxtemp}°";
            minimalna.Text = "minimum temp - " + $"{minTemp}°";
            osjecaj.Text = "feels like - " + $"{feelsLike}°";
            pritisak.Text = "pritisak - " + pressure + " Bar";
            vlaznost.Text = "vlaznost - " + humidity;

            if (icon == "01d")
            {
                BackgroundImageSource = "fog.jpg";
            }
           else if (icon == "01n") {

                BackgroundImageSource = "fog.jpg";
            }

                 

        }

        async void GetWeatherbyCoordinates(double _langitude, double _longitude)
        {
            string apiKey = "54e2387eafb478641f18bf6d2c3cd429";
            string apiBase = $"http://api.openweathermap.org/data/2.5/weather?lat={_langitude}&lon={_longitude}&appid="; 
            string unit = "metric";



            if (double.IsNaN(_longitude))
            {

                notFound.Text = "unesite ispravan grad";

                return;
            }

            if (!CrossConnectivity.Current.IsConnected)
            {
                notFound.Text = "unesite ispravan grad";
                return;
            }


            // Asynchronous API call using HttpClient
            string url = apiBase + apiKey + "&units=" + unit;
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);



            var resultObject = JObject.Parse(result);
            string weatherDescription = resultObject["weather"][0]["description"].ToString();
            string icon = resultObject["weather"][0]["icon"].ToString();
            string temperature = resultObject["main"]["temp"].ToString();
            string placename = resultObject["name"].ToString();
            string country = resultObject["sys"]["country"].ToString();
            string minTemp = resultObject["main"]["temp_min"].ToString();
            string feelsLike = resultObject["main"]["feels_like"].ToString();
            string maxtemp = resultObject["main"]["temp_max"].ToString();
            string pressure = resultObject["main"]["pressure"].ToString();
            string humidity = resultObject["main"]["humidity"].ToString();


            weatherDescription = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(weatherDescription);

            opis.Text = weatherDescription;
            Lokacija.Text = placename + ", " + country;
            temperatura.Text = $"{temperature}°";

            maksimalna.Text = "max - " + $"{maxtemp}°";
            minimalna.Text = "min - " + $"{minTemp}°";
            osjecaj.Text = "feels like - " + $"{feelsLike}°";
            pritisak.Text = "pressure - " + pressure + " Bar";
            vlaznost.Text = "humidity - " + humidity + " %" ;

            if (icon == "01d")
            {
                BackgroundImageSource = "fog.jpg";
            }
            else if (icon == "01n")
            {

                BackgroundImageSource = "fog.jpg";
            }



        }


        protected override void OnAppearing()
        {
            base.OnAppearing();


        string location = Lokacija.Text;
           

            double _Longitude = Convert.ToDouble(Longitude.Text);
            double _Langitude = Convert.ToDouble(Langitude.Text);


            if (location!="")
            {
                GetWeather(location);

                if (icon == "01d")
                {
                    BackgroundImageSource = "clearSd.jpg";
                }
                else if (icon == "01n")
                {

                    BackgroundImageSource = "clearSn.jpg";
                }
                else if (icon == "02d")
                {

                    BackgroundImageSource = "fewCd.jpg";
                }
                else if (icon == "02n")
                {

                    BackgroundImageSource = "fewCn.jpg";
                }
                else if (icon == "03d")
                {

                    BackgroundImageSource = "fewCd.jpg";
                }
                else if (icon == "03n")
                {

                    BackgroundImageSource = "fewCn.jpg";
                }
                else if (icon == "04d")
                {

                    BackgroundImageSource = "brokenC.jpg";
                }
                else if (icon == "04n")
                {

                    BackgroundImageSource = "brokenC.jpg";
                }
                else if (icon == "09d")
                {

                    BackgroundImageSource = "rainD.jpg";
                }
                else if (icon == "09n")
                {

                    BackgroundImageSource = "rainN.jpg";
                }
                else if (icon == "10d")
                {

                    BackgroundImageSource = "rainD.jpg";
                }
                else if (icon == "10n")
                {

                    BackgroundImageSource = "rainN.jpg";
                }
                else if (icon == "11d")
                {

                    BackgroundImageSource = "thunderD.jpg";
                }
                else if (icon == "11n")
                {

                    BackgroundImageSource = "thunderN.jpg";
                }
                else if (icon == "13d")
                {

                    BackgroundImageSource = "snowD.jpg";
                }
                else if (icon == "13n")
                {

                    BackgroundImageSource = "snowN.jpg";
                }
                else if (icon == "50d")
                {

                    BackgroundImageSource = "foggy.jpg";
                }
                else if (icon == "50n")
                {

                    BackgroundImageSource = "fog.jpg";
                }

            }
            else
            {
                GetWeatherbyCoordinates(_Langitude, _Longitude);

            }
            




                    
        }
    }
}
