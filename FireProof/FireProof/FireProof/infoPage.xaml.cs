using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireProof
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class infoPage : ContentPage
	{
        RestService _restService;
        public infoPage ()
		{
			InitializeComponent ();
            _restService = new RestService();
        }
        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
                if (weatherData.Main.Temperature >= 90 || weatherData.Wind.Speed >= 3 || weatherData.Main.Humidity < 30)
                {
                    level.Text = "1";
                }
                else
                {
                    level.Text = "0";
                }

                if ((weatherData.Main.Temperature >= 90 && weatherData.Wind.Speed >= 3)
                || (weatherData.Wind.Speed >= 3 && weatherData.Main.Humidity < 30)
                || (weatherData.Main.Temperature >= 90 && weatherData.Main.Humidity < 30))
                {
                    level.Text = "2";
                }

                if(weatherData.Main.Temperature >= 90 && weatherData.Wind.Speed >= 3 && weatherData.Main.Humidity < 30)
                {
                    level.Text = "3";
                }
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
