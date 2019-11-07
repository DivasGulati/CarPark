using CarPark.Core.DomainModel.Enums;
using CarPark.Core.ValueObjects;
using System;
using System.Collections.Generic;

namespace CarPark.Core
{
    public class Standard : BaseRate
    {
        Dictionary<HourlyRateType, double> _rateMap;

        public Standard()
        {
            _rateMap = new Dictionary<HourlyRateType, double>()
            {
                { HourlyRateType.FirstHour , 5.0},
                { HourlyRateType.SecondHour , 10.0 },
                { HourlyRateType.ThirdHour , 15.0 },
                { HourlyRateType.ThreePlusHours , 20.0 }
            };

            Type = FareType.Hourly;
        }

        
        public override FareType Type { get; set; }


        public override double Calculate(Visit visit)
        {
            var duration = visit.GetDuration();        
            double rate = 0.0;

            if (visit.Entry.Day == visit.Exit.Day && duration <= new TimeSpan(24, 0, 0)) // same day visit
            {
                rate = GetRate(duration);

            }
            else // more than 1 day visit
            {
                var sameDayStartOfDay = new DateTime(visit.Exit.Year, visit.Exit.Month, visit.Exit.Day);
                rate = _rateMap[HourlyRateType.ThreePlusHours] * duration.Days + GetRate(visit.Exit.Subtract(sameDayStartOfDay));

            }

            return rate;

        }

        private double GetRate(TimeSpan duration)
        {
            double rate;
            if (duration <= new TimeSpan(1, 0, 0))
            {
                rate = _rateMap[HourlyRateType.FirstHour];
            }
            else if (duration <= new TimeSpan(2, 0, 0))
            {
                rate = _rateMap[HourlyRateType.SecondHour];
            }
            else if (duration <= new TimeSpan(3, 0, 0))
            {
                rate = _rateMap[HourlyRateType.ThirdHour];
            }
            else
            {
                rate = _rateMap[HourlyRateType.ThreePlusHours];

            }

            return rate;
        }
    }
}
