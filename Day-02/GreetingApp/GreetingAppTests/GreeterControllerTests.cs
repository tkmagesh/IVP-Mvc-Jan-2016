using System;
using System.Diagnostics;
using GreetingApp.Controllers;
using GreetingApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GreetingAppTests
{
    [TestClass]
    public class GreeterControllerTests
    {
        [TestMethod]
        public void Returns_Morning_View_Before_12()
        {
            //Arrange
            var dateTimeMockery = new Mock<IDateTimeService>();
            dateTimeMockery.Setup(s => s.GetCurrent()).Returns(new DateTime(2016, 1, 10, 9, 0, 0));
            var _dateTimeServiceMock = dateTimeMockery.Object;

            var greeterServiceMockery = new Mock<IGreeterService>();
            var _greeterServiceMock = greeterServiceMockery.Object;

            var sut = new GreeterController(_greeterServiceMock, _dateTimeServiceMock);
            var expecedViewName = "MorningView";

            //Act
            var result = sut.Greet(new GreetInput(){FirstName = "Magesh", LastName = "Kuppan"});

            //Assert
            Assert.AreEqual(expecedViewName, result.ViewName);
        }

        [TestMethod]
        public void Returns_Afternoon_View_After_12()
        {
            //Arrange
            var dateTimeMockery = new Mock<IDateTimeService>();
            dateTimeMockery.Setup(s => s.GetCurrent()).Returns(new DateTime(2016, 1, 10, 15, 0, 0));
            var _dateTimeServiceMock = dateTimeMockery.Object;

            var greeterServiceMockery = new Mock<IGreeterService>();
            var _greeterServiceMock = greeterServiceMockery.Object;

            var sut = new GreeterController(_greeterServiceMock, _dateTimeServiceMock);
            var expecedViewName = "AfternoonView";

            //Act
            var result = sut.Greet(new GreetInput() {FirstName = "Magesh", LastName = "Kuppan"});

            //Assert
            Assert.AreEqual(expecedViewName, result.ViewName);
        }

        [TestMethod]
        public void Views_Receive_Message_When_Greeted()
        {
            //Arrange
            var dateTimeMockery = new Mock<IDateTimeService>();
            dateTimeMockery.Setup(s => s.GetCurrent()).Returns(new DateTime(2016, 1, 10, 15, 0, 0));
            var _dateTimeServiceMock = dateTimeMockery.Object;

            var greeterServiceMockery = new Mock<IGreeterService>();
            greeterServiceMockery.Setup(s => s.Greet(Moq.It.IsAny<string>())).Returns("Dummy message");
            
            var _greeterServiceMock = greeterServiceMockery.Object;

            var sut = new GreeterController(_greeterServiceMock, _dateTimeServiceMock);
            var name = "Magesh";
            var expecedMessage = "Dummy message";

            //Act
            var result = sut.Greet(new GreetInput() {FirstName = "Magesh", LastName = "Kuppan"});
        
            //Assert
            //_greeterServiceMock.Greet(It.IsAny<string>()).]
            greeterServiceMockery.Verify(s => s.Greet("Magesh Kuppan"), Times.Once);
            Assert.AreEqual(expecedMessage, result.ViewBag.Message);
        }


    }
}
