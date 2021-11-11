using Newtonsoft.Json;
using OpenWeatherAppication.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OpenWeatherAppication
{
    public class OpenWeatherClient
    {
        private readonly string _apiId;

        private readonly HttpClient _httpClient;

        public OpenWeatherClient(HttpClient httpClient)
        {
            _apiId = ConfigurationManager.AppSettings["apiId"];

            _httpClient = httpClient;
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
            var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_apiId}");
            
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(content);

            return weatherInfo;
        }
    }
}
