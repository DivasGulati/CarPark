using System;

namespace CarPark.Application
{
    public interface IRateService
    {
        double CalculateRate(DateTime entryDateTime, DateTime exitDateTime);
    }
}
