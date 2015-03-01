using System;
using System.Collections.Generic;
using AzureUserManager.Business;
using AzureUserManager.External;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

//namespace AzureUserManager.Tests
//{
//    [TestClass]
//    public class UserStoreTest
//    {
//        private Mock<IActiveDirectoryClientAdapter> _activeDirectoryClientAdapter;

//        [TestInitialize]
//        public void Setup()
//        {
//            _activeDirectoryClientAdapter = new Mock<IActiveDirectoryClientAdapter>();
//        }

//        [TestMethod]
//        public void UserStoreTest_Get_returnsNullOnNotFound()
//        {
//            // Arrange
//            _activeDirectoryClientAdapter.Setup(x => x.GetAllUsers()).Returns(new List<IUser>
//            {

//            });

//            IUserStore userStore = new UserStore(_activeDirectoryClientAdapter.Object);

//            // Act
//            var res = userStore.Get("jonathan");

//            // Assert
//            Assert.IsNull(res);
//        }

//        [TestMethod]
//        public void UserStoreTest_Get_returnsOneUser()
//        {
//            // Arrange
//            _activeDirectoryClientAdapter.Setup(x => x.GetAllUsers()).Returns(new List<IUser>
//            {
//                new User
//                {
//                    UserPrincipalName = "asd",
//                },
//                new User
//                {
//                    UserPrincipalName = "123",
//                }
//            });

//            IUserStore userStore = new UserStore(_activeDirectoryClientAdapter.Object);

//            // Act
//            var res = userStore.Get("asd");

//            // Assert
//            Assert.IsNotNull(res);
//        }
//    }
//}
