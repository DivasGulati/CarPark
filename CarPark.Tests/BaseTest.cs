using CarPark.Application;
using CarPark.Core.Abstractions;
using CarPark.Core;
using CarPark.Core.DomainModel.Enums;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;


namespace CarPark.Tests
{
    public class BaseTest
    {
        protected ServiceProvider _serviceProvider;

        public BaseTest()
        {
            _serviceProvider = ConfigureServices();
        }

        protected ServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<IRateRulesFactory, RateRulesFactory>();
            services.AddTransient<IRateIdentifier, RateIdentifier>();
            services.AddTransient<Dictionary<HourlyRateType, double>, Dictionary<HourlyRateType, double>>();
            return services.BuildServiceProvider();

        }
    }
}
