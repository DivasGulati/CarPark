using CarPark.Core.Abstractions;
using CarPark.Core.DomainModel.Enums;
using CarPark.Core.DomainModel.Rates;
using CarPark.Core.ValueObjects;

namespace CarPark.Core
{
    public class RateRulesFactory : IRateRulesFactory
    {
        IRateIdentifier _rateIdentifier;

        public RateRulesFactory(IRateIdentifier rateIdentifier)
        {
            this._rateIdentifier = rateIdentifier;
        }
        public IFareCalculator GetFare(Visit visit)
        {
            switch (_rateIdentifier.Identify(visit))
            {

                case Rate.EarlyBird:
                    {
                        return new EarlyBird();
                    }
                case Rate.Night:
                    {
                        return new Night();
                    }
                case Rate.Weenkend:
                    {
                        return new Weekend();
                    }
                case Rate.Standard:
                    {
                        return new Standard();
                    }
            }

            return null;
        }
    }
}
