using Xunit;
using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Models.Notification;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using fuquizlearn_api.Entities;
using Microsoft.AspNetCore.Http;

namespace UnitTest.Quizlearn
{
    public class NotificationControllerTests
    {
        [Fact]
        public async Task CreateNotification_ReturnsOk()
        {
            // Arrange
            var fakeNotificationService = A.Fake<INotificationService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new NotificationController(fakeNotificationService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var notificationCreate = new NotificationCreate();

            // Act
            var actionResult = await controller.CreateNotification(notificationCreate);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task DeleteNotification_ReturnsNoContent()
        {
            // Arrange
            var fakeNotificationService = A.Fake<INotificationService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new NotificationController(fakeNotificationService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var id = 1;

            // Act
            var actionResult = await controller.DeleteNotification(id);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task GetCurrentNotifications_ReturnsOk()
        {
            // Arrange
            var fakeNotificationService = A.Fake<INotificationService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new NotificationController(fakeNotificationService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var options = new PagedRequest();

            // Act
            var actionResult = await controller.GetCurrentNotifications(options);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            // Arrange
            var fakeNotificationService = A.Fake<INotificationService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new NotificationController(fakeNotificationService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var options = new PagedRequest();

            // Act
            var actionResult = await controller.GetAll(options);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetNotificationsByAccount_ReturnsOk()
        {
            // Arrange
            var fakeNotificationService = A.Fake<INotificationService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new NotificationController(fakeNotificationService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var accountId = 1;
            var options = new PagedRequest();

            // Act
            var actionResult = await controller.GetNotificationsByAccount(accountId, options);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task UpdateNotification_ReturnsOk()
        {
            // Arrange
            var fakeNotificationService = A.Fake<INotificationService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new NotificationController(fakeNotificationService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var notificationUpdate = new NotificationUpdate();

            // Act
            var actionResult = await controller.UpdateNotification(notificationUpdate);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task MarkNotificationAsRead_ReturnsOk()
        {
            // Arrange
            var fakeNotificationService = A.Fake<INotificationService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new NotificationController(fakeNotificationService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var id = 1;

            // Act
            var actionResult = await controller.MarkNotificationAsRead(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetUnread_ReturnsOk()
        {
            // Arrange
            var fakeNotificationService = A.Fake<INotificationService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new NotificationController(fakeNotificationService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };

            // Act
            var actionResult = await controller.GetUnread();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }
    }
}
