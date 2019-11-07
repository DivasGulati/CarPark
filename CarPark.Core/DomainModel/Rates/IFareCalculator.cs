using CarPark.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Core.DomainModel.Rates
{
    public interface IFareCalculator
    {
        double Calculate(Visit visit);
    }
}
