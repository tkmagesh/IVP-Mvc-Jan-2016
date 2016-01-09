using System;
using GreetingApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingAppTests
{
    public class FakeDateTimeServiceForMorning : IDateTimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2016,01,9,9,0,0);
        }
    }

    public class FakeDateTimeServiceForAfternoon : IDateTimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2016,1,9,15,0,0);
        }
    }

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
