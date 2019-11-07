using CarPark.Core;
using CarPark.Core.Abstractions;
using CarPark.Core.DomainModel.Rates;
using CarPark.Core.ValueObjects;
using System;

namespace CarPark.Application
{
    public class RateService : IRateService
    {
        IRateRulesFactory _rateRulesFactory;

        public RateService(IRateRulesFactory rateRulesFactory)
        {
            this._rateRulesFactory = rateRulesFactory;
        }

        public double CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            Visit visit = new Visit() { Entry = entryDateTime, Exit = exitDateTime };
            IFareCalculator _fareCalculator = _rateRulesFactory.GetFare(visit);
            return _fareCalculator.Calculate(visit);
        }
    }
}
