using Demo.Models;
using OpenWeatherMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public sealed class WeatherService
    {
        private readonly OpenWeatherMapClient _client;

        public WeatherService()
        {
            _client = new OpenWeatherMapClient(
                "bd5e378503939ddaee76f12ad7a97608");
        }

        public async Task<DailyWeatherSummary> GetWeatherSummary(
            String cityName)
        {
            try
            {
                
                CurrentWeatherResponse response =
                    await _client.CurrentWeather
                        .GetByName(cityName, MetricSystem.Metric);

                return new DailyWeatherSummary
                {
                    City = response.City.Name,
                    Description = response.Weather.Value,
                    ImagePath = BuildImagePath(response.Weather.Icon),
                    Temperature = response.Temperature.Value,
                    TemperatureFrom = response.Temperature.Min,
                    TemperatureTo = response.Temperature.Max
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<DailyForecast>> GetWeekForecast(
            String cityName)
        {
            try
            {
                ForecastResponse response =
                    await _client.Forecast.GetByName(
                        cityName, false, MetricSystem.Metric);

                return response.Forecast.GroupBy(f => f.From.Date)
                    .Select(grp => new DailyForecast()
                    {
                        Date = grp.Key,
                        Forecasts = grp.Select(ft => new TimeSpanForecast
                        {
                            FromTime = ft.From,
                            ToTime = ft.To,
                            Temperature = ft.Temperature.Value,
                            TemperatureFrom = ft.Temperature.Min,
                            TemperatureTo = ft.Temperature.Max,
                            ImagePath = BuildImagePath(ft.Symbol.Var)
                        }).ToList()
                    }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private String BuildImagePath(String imageName)
        {
            return $"http://openweathermap.org/img/w/{imageName}.png";
        }
    }
}
