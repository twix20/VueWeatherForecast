using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OpenWeatherMapApiClient.Models.Common;
using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Application.AutoMapper
{
    public class ForecastViewModelProfile : Profile
    {
        public ForecastViewModelProfile()
        {
            CreateMap<Forecast, ForecastViewModel>()
                .ForMember(dest => dest.Days, opts => opts.MapFrom<ForecastDaysResolver>());

            CreateMap<Forecast, ForecastDayViewModel>().ForAllMembers(opts => opts.Ignore());
        }
    }

    public class ForecastDaysResolver : IValueResolver<Forecast, ForecastViewModel, IEnumerable<ForecastDayViewModel>>
    {
        public IEnumerable<ForecastDayViewModel> Resolve(Forecast source, ForecastViewModel destination, IEnumerable<ForecastDayViewModel> destMember, ResolutionContext context)
        {
            var forecastDayGroups = source?.list?.GroupBy(m => DateTime.Parse(m?.dt_txt).ToShortDateString());

            var forecastDays = forecastDayGroups?.Select(g =>
            {
                long? humidity = 0L;
                double? temperature = 0.0d;
                double? windSpeed = 0.0d;

                foreach (var measurement in g)
                {
                    humidity += measurement?.main?.humidity;
                    temperature += measurement?.main?.temp;
                    windSpeed += measurement?.wind?.speed;
                }

                var measurementsCount = g.Count();
                if (measurementsCount > 0)
                {
                    temperature /= measurementsCount;
                    humidity /= measurementsCount;
                    windSpeed /= measurementsCount;
                }

                var date = DateTime.Parse(g.Key);

                return new ForecastDayViewModel()
                {
                    Date = date,
                    AverageTemperature = temperature,
                    Humidity = humidity,
                    WindSpeed = windSpeed
                };
            });

            return forecastDays;
        }
    }
}
