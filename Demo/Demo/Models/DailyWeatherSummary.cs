using System;

namespace Demo.Models
{
    public sealed class DailyWeatherSummary : WeatherInfoBase
    {
        public String City { get; set; }

        public String Description { get; set; }
    }
}
