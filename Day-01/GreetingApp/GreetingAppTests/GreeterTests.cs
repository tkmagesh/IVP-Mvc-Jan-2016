using GreetingApp.Services;
using GreetingAppTests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingAppTests
{
    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void When_Greeted_Before_12_Greets_GoodMorning()
        {
            //Arrange
            var dateTimeServiceForMorning = new FakeDateTimeServiceForMorning();
            var greeter = new Greeter(dateTimeServiceForMorning);
            var name = "Magesh";
            var expectedMessage = "Hi Magesh, Good Morning!!";

            //Act
            greeter.Name = name;
            var message = greeter.Greet();

            //Assert
            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void When_Greeted_After_12_Greets_GoodAfternoon()
        {
            //Arrange
            var fakeDateTimeServiceForAfternoon = new FakeDateTimeServiceForAfternoon();
            var greeter = new Greeter(fakeDateTimeServiceForAfternoon);
            var name = "Magesh";
            var expectedMessage = "Hi Magesh, Good Afternoon!!";

            //Act
            greeter.Name = name;
            var message = greeter.Greet();

            //Assert
            Assert.AreEqual(expectedMessage, message);
        }
    }
}
