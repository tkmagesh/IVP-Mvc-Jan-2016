using System;
using GreetingApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingAppTests
{
    public class FakeGreeter : IGreeter
    {
        public string Name { get; set; }
        public string Greet()
        {
            return "dummy message";
        }
    }

    [TestClass]
    public class GreeterControllerTests
    {
        [TestMethod]
        public void When_Greeted_Returns_The_Message_From_Greeter()
        {
            //Arrage
            var fakeGreeter = new FakeGreeter();
            var controller = new GreeterController(fakeGreeter);
            var expectedResult = "dummy message";

            //Act
            var result = controller.Greet("magseh");

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
