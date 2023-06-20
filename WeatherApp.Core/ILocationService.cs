﻿using WeatherApp.Core.Models;

namespace WeatherApp.Core;

public interface ILocationService
{
    public Task<IPQuery> GetLocationData();
}