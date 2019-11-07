using CarPark.Application;
using CarPark.Core;
using CarPark.Core.Abstractions;
using CarPark.Core.DomainModel.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CarkPark
{
    class Program
    {   
        static void Main(string[] args)
        {   

            while(true)
            {
                Console.WriteLine("Please enter datetime  ! e.g format = 7/11/2019 11:07:33 PM)");
                Console.WriteLine("Enter EntryTime");
                var entryTime = Console.ReadLine();
                

                if(DateTime.TryParse(entryTime, out DateTime dtEntryTime))
                {

                }
                else
                {
                    Console.WriteLine("Starting Over !");
                    continue;
                }

                Console.WriteLine("Enter ExitTime");
                var exitTime = Console.ReadLine();

                if (DateTime.TryParse(exitTime, out DateTime dtExitTime))
                {

                }
                else
                {
                    Console.WriteLine("Starting Over !");
                    continue;
                }

                if(dtEntryTime >= dtExitTime)
                {
                    Console.WriteLine("Exit Time should be greater than entry Time");
                    continue;
                }

                var seriveProvider = ConfigureServices();
                var rateService = seriveProvider.GetService<IRateService>();

                var rate = rateService.CalculateRate(dtEntryTime, dtExitTime);

                
                Console.WriteLine($"Calculated rate  = {rate}");

                Console.WriteLine("Enter 0 to exit and enter to start over");
                var exit = Console.ReadLine();

                if(int.TryParse(exit, out int exitCondition))
                {
                    if (exitCondition == 0) break;
                }
            }
            
        }

        static ServiceProvider ConfigureServices()
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
