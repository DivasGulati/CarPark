using CarPark.Core.DomainModel.Enums;
using CarPark.Core.ValueObjects;
using System;

namespace CarPark.Core
{
    public class EarlyBird : BaseRate
    {
        public EarlyBird()
        {
            Price = Constants.EARLYBIRD_RATE;
            Type = FareType.Flat;
        }

        public  double Price { get; set; }
        public override FareType Type { get; set; }

        public override double Calculate(Visit visit)
        {           
            return Price;
        }
    }
}
