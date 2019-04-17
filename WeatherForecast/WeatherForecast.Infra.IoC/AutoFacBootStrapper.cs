using Autofac;
using AutoMapper;
using OpenWeatherMapApiClient;
using Refit;
using WeatherForecast.Application.AutoMapper;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.Services;

namespace WeatherForecast.Infra.IoC
{
    public static class AutoFacBootStrapper
    {
        public static void RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<WeatherService>().As<IWeatherService>();


            builder
                .Register(c => AutoMapperConfig.RegisterMappings().CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired()
                .PreserveExistingDefaults();
        }
    }
}
