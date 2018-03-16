using System;

namespace Demo.Models
{
    public abstract class WeatherInfoBase
    {
        public String ImagePath { get; set; }

        public Double Temperature { get; set; }

        public Double TemperatureFrom { get; set; }

        public Double TemperatureTo { get; set; }
    }
}
