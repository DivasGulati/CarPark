using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Core.ValueObjects
{
    public class Visit
    {
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }

        public TimeSpan GetDuration()
        {
            return Exit.Subtract(Entry);
        }
    }
}
