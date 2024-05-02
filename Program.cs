using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StockInfoApp
{
    class Program
    {
        private static IConfiguration Configuration { get; set; }
        private static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            SetupConfiguration();
            var apiKey = Configuration["FinnhubApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("API Key is not set in the configuration.");
                return;
            }

            httpClient.DefaultRequestHeaders.Add("X-Finnhub-Token", apiKey);


            var stockSymbol = args.Length > 0 ? args[0] : "MSFT"; 

            try
            {
                var requestUrl = $"https://finnhub.io/api/v1/search?q={stockSymbol}";
                var response = await httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<Result>(jsonResponse);

                if (result != null && result.result != null)
                {
                    foreach (var stock in result.result)
                    {
                        Console.WriteLine($"Symbol: {stock.symbol}, Description: {stock.description}");
                    }
                }
                else
                {
                    Console.WriteLine("No results found.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON Parsing error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        private static void SetupConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();  

            Configuration = builder.Build();
        }

        public class Result
        {
            public int count { get; set; }
            public StockLine[] result { get; set; }
        }

        public class StockLine
        {
            public string symbol { get; set; }
            public string description { get; set; }
        }
    }
}