namespace WeatherApp.Core.Models
{
    public class IPQuery : Entity
    {
        public IPQuery(int? id, string query, double lat, double lon)
        {
            this.Id = id;
            this.query = query;
            this.lat = lat;
            this.lon = lon;
            this.time = DateTime.UtcNow;
        }
        public string query { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public DateTime time;
    }
}