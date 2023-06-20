namespace WeatherApp.Core.Models;

public class CurrentWeatherModel : Entity
{
    public double temperature { get; set; }
    public double windspeed { get; set; }
    public double winddirection { get; set; }
    public int weathercode { get; set; }
    public int is_day { get; set; }
    public DateTime time { get; set; }
}