using Newtonsoft.Json;
using NLog;
using OpenWeatherApiRequest.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherApiRequest
{
    class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        static async Task Main(string[] args)
        {
            await StartAsync();
        }

        public static async Task StartAsync()
        {
            WeatherData weatherData = new WeatherData();

            while (true)
            {
                Console.Write("\nYour city? ");
                var city = Console.ReadLine();

                string info = null;

                try
                {
                    info = await weatherData.GetInfoAsync(city);
                }

                catch (Exception ex)
                {
                    Console.Write("\nWrong name if city");
                    _logger.Info($"City: {city}");
                    _logger.Error(ex.Message);
                }

                Console.WriteLine($"\n{info}");

                Console.Write("Do you want repeat? (any button - repeat, n - exit) : ");
                var answer = Console.ReadKey();

                if (answer.Key == ConsoleKey.N)
                    break;
            }
        }
    }
}
