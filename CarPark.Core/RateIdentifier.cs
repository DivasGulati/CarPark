using System;
using System.Collections.Generic;
using System.Text;
using CarPark.Core.Abstractions;
using CarPark.Core.DomainModel.Enums;
using CarPark.Core.ValueObjects;

namespace CarPark.Core
{
    public class RateIdentifier : IRateIdentifier
    {
        public Rate Identify(Visit visit)
        {
            if (EvaluateEarlyBird(visit))
            {
                return Rate.EarlyBird;
            }
            else if (EvaluateNight(visit))
            {
                return Rate.Night;
            }
            else if (EvaluateWeekend(visit))
            {
                return Rate.Weenkend;
            }

            return Rate.Standard;
        }

        private bool EvaluateWeekend(Visit visit)
        {
            var duration = visit.GetDuration();
            DateTime mondayMorning = default(DateTime);
            var result = false;
            
            
            if (visit.Entry.DayOfWeek == DayOfWeek.Saturday )
            {
                mondayMorning = EvaluateWeekend_Helper(visit,2);
                
            }
            else if (visit.Entry.DayOfWeek == DayOfWeek.Sunday)
            {
                mondayMorning = EvaluateWeekend_Helper(visit, 1);
               
            }
            else
            {
                return false;
            }


            if (visit.Exit <= mondayMorning) result = true;          

            return result;

            
        }

        private DateTime EvaluateWeekend_Helper(Visit visit, int numDays)
        {
            return new DateTime(visit.Entry.Year, visit.Entry.Month, visit.Entry.Day, 0, 0, 0).AddDays(numDays);
        }

        private bool EvaluateNight(Visit visit)
        {
            var duration = visit.GetDuration();

            var nextDaySixAmTime = new DateTime(visit.Entry.Year, visit.Entry.Month, visit.Entry.Day, 6,0,0).AddDays(1);


            TimeSpan nEntryCondtion1 = new TimeSpan(18, 0, 0); //10 o'clock
            TimeSpan nEntryCondtion2 = new TimeSpan(24, 0, 0); //12 o'clock
            TimeSpan nExitCondition1 = new TimeSpan(6, 0, 0); //10 o'clock

            return visit.Entry.TimeOfDay >= nEntryCondtion1 
                          && visit.Exit <= nextDaySixAmTime &&
                          (visit.Entry.DayOfWeek != DayOfWeek.Saturday && visit.Entry.DayOfWeek != DayOfWeek.Sunday);
        }

        private bool EvaluateEarlyBird(Visit visit)
        {
            var duration = visit.GetDuration();

            TimeSpan ebEntryCondtion1 = new TimeSpan(6, 0, 0); //10 o'clock
            TimeSpan ebEntryCondtion2 = new TimeSpan(9, 0, 0); //12 o'clock
            TimeSpan ebExitCondition1 = new TimeSpan(15, 30, 0); //10 o'clock
            TimeSpan ebExitCondition2 = new TimeSpan(23, 30, 0); //12 o'clock

            return visit.Entry.TimeOfDay >= ebEntryCondtion1 && visit.Entry.TimeOfDay <= ebEntryCondtion2
                            && visit.Exit.TimeOfDay >= ebExitCondition1 && visit.Exit.TimeOfDay <= ebExitCondition2
                            && duration <= new TimeSpan(23, 59, 59) && visit.Entry.Day == visit.Exit.Day;
        }
    }
}
