using System;
using GreetingApp.Contracts;

namespace GreetingApp.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        } 
    }
}