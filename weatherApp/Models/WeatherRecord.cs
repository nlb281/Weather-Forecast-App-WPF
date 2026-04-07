using System.Text.Json.Serialization;

namespace weatherApp.Models;

public class WeatherResponse
{
    [JsonPropertyName("fact")]
    public Fact Fact { get; set; } = new();
}

public class Fact
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }
    
    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }
    
    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }
    
    [JsonPropertyName("pressure_mm")]
    public double Pressure { get; set; }
    
    [JsonPropertyName("wind_speed")]
    public double WindSpeed { get; set; }
    
    [JsonPropertyName("condition")]
    public string Condition { get; set; } = string.Empty;
    
    [JsonPropertyName("icon")]
    public string Icon { get; set; } = string.Empty;
}