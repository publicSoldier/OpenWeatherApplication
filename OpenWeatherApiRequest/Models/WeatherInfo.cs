using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenWeatherApiRequest.Models
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
