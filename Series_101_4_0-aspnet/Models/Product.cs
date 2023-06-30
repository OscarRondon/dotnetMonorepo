using System.Text.Json;
using System.Text.Json.Serialization;

namespace Series_101_4_0_aspnet.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        public string maker { get; set; }
        public string img { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }

}
