using NLog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherAppication
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
            HttpClient httpClient = new HttpClient();

            OpenWeatherClient openWeatherClient = new OpenWeatherClient(httpClient);

            while (true)
            {
                Console.Write("\nYour city? ");
                var city = Console.ReadLine();

                string info = null;

                try
                {
                    info = await openWeatherClient.GetInfoAsync(city);
                }
                catch (Exception ex)
                {
                    Console.Write("\nWrong name if city");
                    _logger.Error($"City - {city}, message - {ex.Message}");
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
