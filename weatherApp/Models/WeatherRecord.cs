namespace weatherApp.Models;

public class WeatherRecord
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double Pressure { get; set; }
    public double WindSpeed { get; set; }
}