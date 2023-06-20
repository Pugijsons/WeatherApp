using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Core.Models;

public abstract class Entity
{
    public int Id { get; set; }
}