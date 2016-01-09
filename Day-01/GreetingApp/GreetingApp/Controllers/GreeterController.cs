using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreetingApp.Controllers
{
    public interface IDateTimeService
    {
        DateTime GetCurrentTime();
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        } 
    }
    public class GreeterController : Controller
    {
        private readonly IGreeter _greeter;
        
        public GreeterController(IGreeter greeter)
        {
            _greeter = greeter;
            
        }

        public string Greet(string name)
        {
            _greeter.Name = name;
            var response = _greeter.Greet();
            return response;
        }
    }

    public interface IGreeter
    {
        string Name { get; set; }
        string Greet();
    }

    public class Greeter : IGreeter
    {
        private readonly IDateTimeService _dateTimeService;
        public string Name { get; set; }

        public Greeter(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public string Greet()
        {
            var message = string.Empty;
            if (_dateTimeService.GetCurrentTime().Hour < 12)
            {
                message = string.Format("Hi {0}, Good Morning!!", this.Name);
            }
            else
            {
                message = string.Format("Hi {0}, Good Afternoon!!", this.Name);
            }
            return message;
        }
    }
}