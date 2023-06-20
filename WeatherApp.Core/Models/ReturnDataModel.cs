namespace WeatherApp.Core.Models;

public class ReturnDataModel
{
    public string Temperature { get; set; }
    public string Windspeed { get; set; }
    public string Winddirection { get; set; }
    public string WeatherDescription { get; set; }
    public bool IsDay { get; set; }
    public string Time { get; set; }
}