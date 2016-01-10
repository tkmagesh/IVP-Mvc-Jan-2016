using System;
using GreetingApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingAppTests
{
    [TestClass]
    public class GreeterServiceTests
    {
        [TestMethod]
        public void When_Greeted_Before_12_Returns_GoodMorning()
        {
            //Arrange
            var mockery = new Moq.Mock<IDateTimeService>();
            mockery.Setup(s => s.GetCurrent()).Returns(new DateTime(2016, 1, 10, 9, 0, 0));
            var mockDateTimeService = mockery.Object;

            var greeterService = new GreeterService(mockDateTimeService);
            var name = "Magesh";
            var expectedMessage = "Hi Magesh, Good Morning!";

            //Act
            var greetMessage = greeterService.Greet(name);

            //Assert
            Assert.AreEqual(expectedMessage, greetMessage);
        }
        [TestMethod]
        public void When_Greeted_After_12_Returns_GoodAfternoon()
        {
            //Arrange
            var mockery = new Moq.Mock<IDateTimeService>();
            mockery.Setup(s => s.GetCurrent()).Returns(new DateTime(2016, 1, 10, 15, 0, 0));
            var mockDateTimeService = mockery.Object;

            var greeterService = new GreeterService(mockDateTimeService);
            var name = "Magesh";
            var expectedMessage = "Hi Magesh, Good Afternoon!";

            //Act
            var greetMessage = greeterService.Greet(name);

            //Assert
            Assert.AreEqual(expectedMessage, greetMessage);
        }
    }
}
