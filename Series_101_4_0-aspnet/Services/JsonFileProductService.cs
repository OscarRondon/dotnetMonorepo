using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Series_101_4_0_aspnet.Models;

namespace Series_101_4_0_aspnet.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "mockData", "products.json"); }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddRating(string prodId, int rating)
        {
            IEnumerable<Product> products = GetProducts();

            Product prod = products.First(x => x.id == prodId);
            List<int> ratings = null;

            ratings = prod.Ratings != null ? prod.Ratings.ToList() : new List<int>();

            ratings.Add(rating);
            prod.Ratings = ratings.ToArray();

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                prod.Ratings = ratings.ToArray();
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions { SkipValidation = true, Indented = true }), products
                );
            }
        }
    }
}