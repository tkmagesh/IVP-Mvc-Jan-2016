using System;
using GreetingApp.Contracts;

namespace GreetingAppTests.Fakes
{
    public class FakeDateTimeServiceForAfternoon : IDateTimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2016,1,9,15,0,0);
        }
    }
}