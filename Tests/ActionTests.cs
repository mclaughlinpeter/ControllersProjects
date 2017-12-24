using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void HomeController_ReceiveForm_Redirects()
        {
            // Arrange
            var tempHttpContext = new Mock<HttpContext>();
            var tempDataProvider = new Mock<SessionStateTempDataProvider>();
            var tempDataMock = new Mock<TempDataDictionary>(tempHttpContext.Object, tempDataProvider.Object);
            HomeController controller = new HomeController(); 
            controller.TempData = tempDataMock.Object;

            // Act
            RedirectToActionResult result = controller.ReceiveForm("Adam", "London");

            // Assert
            Assert.Equal("Data", result.ActionName);
        }

        [Fact]
        public void HomeController_ReceiveForm_PopulatesTempData()
        {
            // Arrange
            var tempHttpContext = new Mock<HttpContext>();
            var tempDataProvider = new Mock<SessionStateTempDataProvider>();
            var tempDataMock = new Mock<TempDataDictionary>(tempHttpContext.Object, tempDataProvider.Object);
            HomeController controller = new HomeController(); 
            controller.TempData = tempDataMock.Object;

            // Act
            RedirectToActionResult result = controller.ReceiveForm("Adam", "London");

            // Assert
            Assert.True(controller.TempData.ContainsKey("name"));
            Assert.Equal("Adam", controller.TempData["name"]);
            Assert.True(controller.TempData.ContainsKey("city"));
            Assert.Equal("London", controller.TempData["city"]);
        }


        [Fact]
        public void ModelObjectType()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            ViewResult result = controller.Index();

            // Assert
            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
            Assert.IsType<System.DateTime>(result.ViewData["Date"]);
        }

        [Fact]
        public void Redirection()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectToActionResult result = controller.Redirect();

            // Assert
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);          
        }

        [Fact]
        public void JsonActionMethod()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            JsonResult result = controller.IndexJson();

            // Assert
            Assert.Equal(new[] { "Alice", "Bob", "Joe" }, result.Value);
        }
    }
}