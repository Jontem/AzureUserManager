using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AzureUserManager.Business;
using AzureUserManager.Controllers;
using AzureUserManager.ViewModel;
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
        public async Task UserApiControllerTest_Get_returnsNotFound()
        {
            // Arrange

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Get("Jonathan");
            
            // Assert
            Assert.IsInstanceOfType(res, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task UserApiControllerTest_Get_returnsInteralServerError()
            {
            // Arrange
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Throws(new Exception("asd"));

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Get("Jonathan");

            // Assert
            Assert.IsInstanceOfType(res, typeof(ExceptionResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Get_returnsOk()
        {
            // Arrange
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<IAzureUser>(new UserViewModel { FirstName = "Jonathan" }));

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Get("Jonathan") as OkNegotiatedContentResult<UserViewModel>;

            // Assert
            Assert.IsInstanceOfType(res.Content, typeof(IAzureUser));
        }

        [TestMethod]
        public void UserControllerTest_Post_returnBadRequest()
        {
            // Arrange
            var user = new UserViewModel { FirstName = "Jonathan" };

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
            _userStore.Setup(x => x.AddUser(It.IsAny<IAzureUser>())).Throws(new Exception("asd"));
            var user = new UserViewModel { FirstName = "Jonathan" };

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
            var user = new UserViewModel { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = controller.Post(user);

            // Assert
            _userStore.Verify(x => x.AddUser(It.IsAny<IAzureUser>()));
            Assert.IsInstanceOfType(res, typeof(OkResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Put_returnBadRequest()
        {
            // Arrange
            var user = new UserViewModel { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            controller.ModelState.AddModelError("error", "error");
            var res = await controller.Put(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Put_returnsInternalServerError()
        {
            // Arrange
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Throws(new Exception("asd"));
            var user = new UserViewModel { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Put(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(ExceptionResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Put_returnsNotFound()
        {
            // Arrange
            UserViewModel fakeUser = null;
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<IAzureUser>(fakeUser));
            var user = new UserViewModel { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res =  await controller.Put(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Put_returnsInternalServerErrorOnUpdate()
        {
            // Arrange
            var user = new UserViewModel { FirstName = "Jonathan", LastName = "Mourtada", UserId = "jonte" };
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<IAzureUser>(user));
            _userStore.Setup(x => x.UpdateUser(It.IsAny<IAzureUser>())).Throws(new Exception("asd"));

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Put(user);

            // Assert
            _userStore.Verify(x => x.UpdateUser(It.IsAny<IAzureUser>()));
            Assert.IsInstanceOfType(res, typeof(ExceptionResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Put_returnsOk()
        {
            // Arrange
            var user = new UserViewModel { FirstName = "Jonathan", LastName = "Mourtada", UserId = "jonte" };
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<IAzureUser>(user));

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Put(user);

            // Assert
            _userStore.Verify(x => x.UpdateUser(It.IsAny<IAzureUser>()));
            Assert.IsInstanceOfType(res, typeof(OkResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Delete_returnsBadRequest()
        {
            // Arrange
            var user = new UserViewModel { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            controller.ModelState.AddModelError("error", "error");
            var res = await controller.Delete(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Delete_returnsInternalServerError()
        {
            // Arrange
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Throws(new Exception("asd"));
            var user = new UserViewModel { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Delete(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(ExceptionResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Delete_returnsNotFound()
        {
            // Arrange
            var user = new FakeUser { FirstName = "Jonathan" };

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Delete(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Delete_returnsInternalServerErrorOnDelete()
        {
            // Arrange
            var user = new UserViewModel() { FirstName = "Jonathan" };
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<IAzureUser>(user));
            _userStore.Setup(x => x.DeleteUser(It.IsAny<IAzureUser>())).Throws(new Exception("asd"));

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Delete(user);

            // Assert
            _userStore.Verify(x => x.DeleteUser(It.IsAny<IAzureUser>()));
            Assert.IsInstanceOfType(res, typeof(ExceptionResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Delete_returnsOk()
        {
            // Arrange
            var user = new UserViewModel() { FirstName = "Jonathan" };
            _userStore.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<IAzureUser>(user));

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Delete(user);

            // Assert
            _userStore.Verify(x => x.DeleteUser(It.IsAny<IAzureUser>()));
            Assert.IsInstanceOfType(res, typeof(OkResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Find_returnInternalServerError()
        {
            // Arrange
            _userStore.Setup(x => x.SearchUser(It.IsAny<string>())).Throws(new Exception("asd"));

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Find("jonathan");

            // Assert
            _userStore.Verify(x => x.SearchUser(It.IsAny<string>()));
            Assert.IsInstanceOfType(res, typeof(ExceptionResult));
        }

        [TestMethod]
        public async Task UserControllerTest_Find_returnsOk()
        {
            // Arrange
            _userStore.Setup(x => x.SearchUser(It.IsAny<string>())).Returns(Task.FromResult<IEnumerable<IAzureUser>>(new List<IAzureUser>
            {
                new UserViewModel(),
                new UserViewModel(),
            }));

            // Act
            var controller = new UserApiController(_userStore.Object);
            var res = await controller.Find("jonathan") as OkNegotiatedContentResult<List<UserViewModel>>;

            // Assert
            _userStore.Verify(x => x.SearchUser(It.IsAny<string>()));
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Content.Count(), 2);
        }
        
    }
}
