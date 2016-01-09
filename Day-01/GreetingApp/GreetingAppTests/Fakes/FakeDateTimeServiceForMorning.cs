using System;
using GreetingApp.Contracts;

namespace GreetingAppTests.Fakes
{
    public class FakeDateTimeServiceForMorning : IDateTimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2016,01,9,9,0,0);
        }
    }
}