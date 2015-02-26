using System;
using System.Web.Http.Results;
using AzureUserManager.Business;
using AzureUserManager.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AzureUserManager.Tests
{
    [TestClass]
    public class UserApiControllerTest
    {
        private Mock<IUserStore> _userStore;

        [TestInitialize]
        public void Setup()
        {
            _userStore = new Mock<IUserStore>();
        }

        [TestMethod]
        public void UserApiControllerTest_Get_returnsNotFound()
        {
            // Arrange

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = controller.Get("Jonathan");
            
            // Assert
            Assert.IsInstanceOfType(res, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UserControllerTest_Get_returnsOk()
        {
            // Arrange
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Returns(new FakeUser { FirstName = "Jonathan" });

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = controller.Get("Jonathan") as OkNegotiatedContentResult<AzureUser>;

            // Assert
            Assert.IsInstanceOfType(res.Content, typeof(AzureUser));
        }

        [TestMethod]
        public void UserControllerTest_Post_returnBadRequest()
        {
            // Arrange
            var user = new FakeUser { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            controller.ModelState.AddModelError("error", "error");
            var res = controller.Post(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void UserControllerTest_Post_returnsInternalServerError()
        {
            // Arrange
            _userStore.Setup(x => x.AddUser(It.IsAny<AzureUser>())).Throws(new Exception("asd"));
            var user = new FakeUser { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = controller.Post(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(ExceptionResult));
        }

        [TestMethod]
        public void UserControllerTest_Post_returnsOk()
        {
            // Arrange
            var user = new FakeUser { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = controller.Post(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(OkResult));
        }
    }
}
