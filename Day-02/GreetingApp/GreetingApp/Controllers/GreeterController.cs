using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            return View(new GreetInput());
        }

        public ViewResult Greet(GreetInput greetInput)
        {
            //var greetInput = new GreetInput() {FirstName = firstName, LastName = lastName};
            //var fullName = string.Format("{0} {1}", firstName, lastName);
            //greetInput.Validate();
            if (!this.ModelState.IsValid)
                return View("Index", greetInput);
            var message =  _greeterService.Greet(greetInput.FullName);
            this.ViewBag.Message = message;

            if (_dateTimeService.GetCurrent().Hour < 12)
                return View("MorningView");
            return View("AfternoonView");
        }
    }

    /*public class GreetInput
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
           
        }

        public IDictionary<string, string> ErrorMessages { get; set; }

        public GreetInput()
        {
            ErrorMessages = new Dictionary<string, string>();
        }

        public bool IsValid
        {
            get { return ErrorMessages.Count <= 0; }
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
                ErrorMessages.Add("FirstName", "First name cannot be empty!");
            if (string.IsNullOrEmpty(LastName))
                ErrorMessages.Add("LastName", "Last name cannot be empty!");

        }
    }*/

    public class GreetInput
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}