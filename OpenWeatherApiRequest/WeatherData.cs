using Newtonsoft.Json;
using OpenWeatherApiRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OpenWeatherApiRequest
{
    public class WeatherData
    {
        private readonly string _apiId;

        public WeatherData()
        {
            _apiId = ConfigurationManager.AppSettings["apiId"];
        }

        public async Task<string> GetInfoAsync(string city)
        {
            var weatherInfo = await GetWeatherAsync(city);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Weather in {weatherInfo.Name}:");
            sb.AppendLine($"temperature {weatherInfo.Main.Temp} °С, feel like {weatherInfo.Main.FeelsLike} °C");
            sb.AppendLine($"{weatherInfo.Weather.FirstOrDefault().Description}");
            sb.AppendLine($"wind is {weatherInfo.Wind.Speed} m/s");

            return sb.ToString();
        }

        private async Task<WeatherInfo> GetWeatherAsync(string city)
        {     
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_apiId}");
            
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(content);

            return weatherInfo;
        }
    }
}
