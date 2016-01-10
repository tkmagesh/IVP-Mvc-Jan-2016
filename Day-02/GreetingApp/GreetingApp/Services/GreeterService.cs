using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreetingApp.Services
{
    public interface IGreeterService
    {
        string Greet(string name);
    }

    public class GreeterService : IGreeterService
    {
        private readonly IDateTimeService _dateTimeService;

        public GreeterService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public string Greet(string name)
        {
            if (_dateTimeService.GetCurrent().Hour < 12)
            {
                return string.Format("Hi {0}, Good Morning!", name);
            }
            return string.Format("Hi {0}, Good Afternoon!", name);
        }
    }

    public interface IDateTimeService
    {
        DateTime GetCurrent();
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}