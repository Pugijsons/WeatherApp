namespace WeatherApp.Core.Models;

public class IPCallResponseModel : Entity
{
    public string query { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
}