using CarPark.Core.DomainModel.Enums;
using CarPark.Core.ValueObjects;
using System;

namespace CarPark.Core
{
    public class Weekend : BaseRate
    {
        public Weekend()
        {
            Price = Constants.WEEKEND_RATE;
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
