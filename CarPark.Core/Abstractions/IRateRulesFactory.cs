using CarPark.Core.DomainModel.Rates;
using CarPark.Core.ValueObjects;

namespace CarPark.Core.Abstractions
{
    public interface IRateRulesFactory
    {
        IFareCalculator GetFare(Visit visit);
    }
}