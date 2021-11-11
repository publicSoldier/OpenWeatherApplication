using System.Collections.Generic;
using Newtonsoft.Json;
using OpenWeatherAppication.Models;

namespace OpenWeatherAppication.Models
{
    public class WeatherInfo
    {
        [JsonProperty("weather")]
        public IReadOnlyCollection<Weather> Weather { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
