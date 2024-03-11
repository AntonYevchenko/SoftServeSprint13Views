using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewTask.Services
{
    public class SimpleTimeService : ITimeService
    {
        public string GetTimeForTomorrow() => DateTime.Now.AddDays(1).ToShortDateString();
    }
}