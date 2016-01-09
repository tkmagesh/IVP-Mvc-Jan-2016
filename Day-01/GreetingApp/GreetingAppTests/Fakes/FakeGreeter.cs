using GreetingApp.Contracts;

namespace GreetingAppTests.Fakes
{
    public class FakeGreeter : IGreeter
    {
        public string Name { get; set; }
        public string Greet()
        {
            return "dummy message";
        }
    }
}