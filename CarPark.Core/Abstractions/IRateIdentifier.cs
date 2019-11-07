using CarPark.Core.DomainModel.Enums;
using CarPark.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Core.Abstractions
{
    public interface IRateIdentifier
    {
        Rate Identify(Visit visit);
    }
}
