using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.Commands;
using Demo.Models;
using Demo.Services;

namespace Demo.ViewModels
{
    public sealed class WeatherViewModel : ViewModelBase
    {
        private DailyWeatherSummary _summary;
        private ObservableCollection<DailyForecast> _forecasts;

        private readonly WeatherService _service;
        private String _searchText;
        private Boolean _isLoading;

        public DailyWeatherSummary Summary
        {
            get => _summary;
            set
            {
                _summary = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DailyForecast> Forecasts
        {
            get => _forecasts;
            set
            {
                _forecasts = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
                LoadWeatherCommand.RaiseCanExecuteChanged();
            }
        }

        public String SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                LoadWeatherCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand LoadWeatherCommand { get; set; }

        public WeatherViewModel()
        {
            _service = new WeatherService();

            Forecasts = new ObservableCollection<DailyForecast>();
            LoadWeatherCommand = new DelegateCommand(OnLoadWeatherExecuted, OnLoadWeatherCanExecute);
        }

        private Boolean OnLoadWeatherCanExecute(Object arg)
        {
            return !IsLoading && !String.IsNullOrEmpty(SearchText);
        }

        private async void OnLoadWeatherExecuted(Object obj)
        {
            Forecasts.Clear();
            IsLoading = true;
            Summary = await _service.GetWeatherSummary(SearchText);

            List<DailyForecast> forecasts = await _service.GetWeekForecast(SearchText);

            forecasts?.ForEach(f => Forecasts.Add(f));
            SearchText = String.Empty;
            
            IsLoading = false;
        }
    }
}
