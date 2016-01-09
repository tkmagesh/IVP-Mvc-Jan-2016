using GreetingApp.Contracts;

namespace GreetingApp.Services
{
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