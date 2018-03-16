using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class TimeSpanForecast : WeatherInfoBase
    {
        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }
    }
}
