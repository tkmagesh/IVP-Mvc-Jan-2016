using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreetingApp.Services;

namespace GreetingApp.Controllers
{
    public class GreeterController : Controller
    {
        private IGreeterService _greeterService;
        private readonly IDateTimeService _dateTimeService;

        public GreeterController(IGreeterService greeterService, IDateTimeService dateTimeService)
        {
            _greeterService = greeterService;
            _dateTimeService = dateTimeService;
        }

        public GreeterController()
        {
            _dateTimeService = new DateTimeService();
            _greeterService = new GreeterService(_dateTimeService);
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Greet(GreetInput greetInput)
        {
            //var greetInput = new GreetInput() {FirstName = firstName, LastName = lastName};
            //var fullName = string.Format("{0} {1}", firstName, lastName);
            var message =  _greeterService.Greet(greetInput.FullName);
            this.ViewBag.Message = message;

            if (_dateTimeService.GetCurrent().Hour < 12)
                return View("MorningView");
            return View("AfternoonView");
        }
    }

    public class GreetInput
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
           
        }
    }
}