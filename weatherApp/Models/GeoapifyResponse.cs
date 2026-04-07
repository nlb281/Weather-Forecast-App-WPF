using System.Text.Json.Serialization;

namespace weatherApp.Models;

public class GeoapifyResponse
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; } = new();
    
    public class Feature
    {
        [JsonPropertyName("properties")]
        public Coordinates Properties { get; set; } = new();
    }
    
    public class Coordinates
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
        
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }
}