//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
//using Moq;
//using System.Threading.Tasks;
//using Jokify.Controllers;
//using Jokify.Core.Models.User;
//using NUnit.Framework;
//using Jokify.Infrastructure.Data.Models;
//using static System.Formats.Asn1.AsnWriter;

//namespace Jokify.UnitTests.UserControllerTests
//{
//    [TestFixture]
//    public class UserControllerTests
//    {
//        private UserController GetUserController(UserManager<User> userManager, SignInManager<User> signInManager)
//        {
//            return new UserController(userManager, signInManager);
//        }

//        [Test]
//        public async Task Register_ValidModel_ReturnsRedirectToActionResult()
//        {
//            // Arrange
//            var store = new Mock<IUserStore<User>>();
//            var userManagerMock = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
//            var signInManagerMock = new Mock<SignInManager<User>>(userManagerMock.Object, null, null, null, null, null);
//            var controller = GetUserController(userManagerMock.Object, signInManagerMock.Object);
//            var model = new RegisterViewModel
//            {
//                UserName = "testuser",
//                Email = "testuser@example.com",
//                Password = "Test123!"
//            };

//            userManagerMock.Setup(um => um.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

//            // Act
//            var result = await controller.Register(model) as RedirectToActionResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.That(result.ActionName, Is.EqualTo("Index"));
//            Assert.That(result.ControllerName, Is.EqualTo("Home"));
//        }

//        [Test]
//        public async Task Login_ValidModel_ReturnsRedirectToActionResult()
//        {
//            // Arrange
//            var store = new Mock<IUserStore<User>>();
//            var userManagerMock = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
//            var signInManagerMock = new Mock<SignInManager<User>>(userManagerMock.Object, null, null, null, null, null);
//            var controller = GetUserController(userManagerMock.Object, signInManagerMock.Object);
//            var model = new LoginViewModel
//            {
//                UserName = "testuser",
//                Password = "Test123!"
//            };

//            userManagerMock.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new User { UserName = model.UserName });

//            //signInManagerMock.Setup(sm => sm.PasswordSignInAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).ReturnsAsync(SignInResult.Success);

//            // Act
//            var result = await controller.Login(model) as RedirectToActionResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.AreEqual("Index", result.ActionName);
//            Assert.AreEqual("Home", result.ControllerName);
//        }
//    }
//}