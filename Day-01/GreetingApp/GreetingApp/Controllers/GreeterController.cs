using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreetingApp.Contracts;
using GreetingApp.Services;

namespace GreetingApp.Controllers
{
    public class GreeterController : Controller
    {
        private readonly IGreeter _greeter;
        private readonly IDateTimeService _dateTimeService;

        public GreeterController(IGreeter greeter, IDateTimeService dateTimeService)
        {
            _greeter = greeter;
            _dateTimeService = dateTimeService;
        }

        public GreeterController()
        {
            _dateTimeService = new DateTimeService();
            _greeter = new Greeter(_dateTimeService);
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Greet(string name)
        {
            _greeter.Name = name;
            var response = _greeter.Greet();
            this.ViewData["message"] = response;
            if (_dateTimeService.GetCurrentTime().Hour < 12)
                return View("MorningView");
            return View("AfternoonView");
            //return response;

        }
    }
}