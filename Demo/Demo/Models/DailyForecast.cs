using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public sealed class DailyForecast
    {
        public DateTime Date { get; set; }

        public List<TimeSpanForecast> Forecasts { get; set; }
    }
}
