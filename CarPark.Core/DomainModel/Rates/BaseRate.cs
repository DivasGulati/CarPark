using CarPark.Core.DomainModel.Enums;
using CarPark.Core.DomainModel.Rates;
using CarPark.Core.ValueObjects;
using System;

namespace CarPark.Core
{
    

    public abstract class BaseRate : IFareCalculator
    {
     //   public abstract double Price{ get; set; }
        public abstract FareType Type { get; set; }
        public abstract double Calculate(Visit visit);        
    }
       
}
