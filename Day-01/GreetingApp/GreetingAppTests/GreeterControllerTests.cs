using System;
using System.Web.Mvc;
using GreetingApp.Controllers;
using GreetingApp.Models;
using GreetingApp.Services;
using GreetingAppTests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingAppTests
{
    [TestClass]
    public class GreeterControllerTests
    {
        [TestMethod]
        public void When_Greeted_GreeterMessage_Is_Rendered()
        {
            //Arrange
            var fakeGreeter = new FakeGreeter();
            var fakeDateTimeServiceForMorning = new FakeDateTimeServiceForMorning();
            var controller = new GreeterController(fakeGreeter, fakeDateTimeServiceForMorning);
            var expectedMessage = fakeGreeter.Greet();
            var greetInput = new GreetInput();
            //Act
            var viewResult = controller.Greet(greetInput);

            //Assert
            Assert.AreEqual(expectedMessage, viewResult.ViewData["message"]);
        }
        [TestMethod]
        public void When_Greeted_In_The_Morning_Returns_MorningView()
        {
            //Arrage
            var fakeGreeter = new FakeGreeter();
            var fakeDateTimeServiceForMorning = new FakeDateTimeServiceForMorning();
            var controller = new GreeterController(fakeGreeter, fakeDateTimeServiceForMorning);
            var expectedViewName = "MorningView";
            var greetInput = new GreetInput();
            //Act
            var result = controller.Greet(greetInput);

            //Assert
            Assert.AreEqual(expectedViewName, result.ViewName);
        }

        [TestMethod]
        public void When_Greeted_In_The_Afternoon_Returns_AfternoonView()
        {
            //Arrage
            var fakeGreeter = new FakeGreeter();
            var fakeDateTimeServiceForAfternoon = new FakeDateTimeServiceForAfternoon();
            var controller = new GreeterController(fakeGreeter, fakeDateTimeServiceForAfternoon);
            var expectedViewName = "AfternoonView";
            var greetInput = new GreetInput();

            //Act
            var result = controller.Greet(greetInput);

            //Assert
            Assert.AreEqual(expectedViewName, result.ViewName);
        }
    }
}
