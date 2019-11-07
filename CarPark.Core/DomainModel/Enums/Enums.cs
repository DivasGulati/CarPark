using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Core.DomainModel.Enums
{
    public enum Rate
    {
    
        EarlyBird,         
        Night,    
        Weenkend,
        Standard
    }

    public enum FareType
    {
        Flat,
        Hourly
    }

    public enum HourlyRateType
    {
        FirstHour,
        SecondHour,
        ThirdHour,
        ThreePlusHours
    }
}
