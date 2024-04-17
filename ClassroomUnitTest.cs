using Xunit;
using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;
using fuquizlearn_api.Models.Classroom;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Models.Response;
using System.Threading.Tasks;
using fuquizlearn_api.Entities;
using Microsoft.AspNetCore.Http;

namespace UnitTest.Quizlearn
{
    public class ClassroomsControllerTests
    {
        [Fact]
        public async Task CreateClassroom_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount); // Extension method to set fake Account
            var classroomCreate = new ClassroomCreate();

            // Act
            var actionResult = await controller.CreateClassroom(classroomCreate);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetClassroomById_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var id = 1;

            // Act
            var actionResult = await controller.GetClassroomById(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
        [Fact]
        public async Task GetAllMember_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var id = 1;
            var options = new PagedRequest();

            // Act
            var actionResult = await controller.GetAllMember(id, options);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetAllClassrooms_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var options = new PagedRequest();

            // Act
            var actionResult = await controller.GetAllClassrooms(options);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
        [Fact]
        public async Task AddMember_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var addMember = new AddMember();

            // Act
            var actionResult = await controller.AddMember(addMember);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task BatchAddMember_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var classroomId = 1;
            var batchMemberRequest = new BatchMemberRequest();

            // Act
            var actionResult = await controller.BatchAddMember(classroomId, batchMemberRequest);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }
        [Fact]
        public async Task RemoveMember_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var memberId = 1;
            var classroomId = 1;

            // Act
            var actionResult = await controller.RemoveMember(memberId, classroomId);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task BatchRemoveMember_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var classroomId = 1;
            var batchMemberRequest = new BatchMemberRequest();

            // Act
            var actionResult = await controller.BatchRemoveMember(classroomId, batchMemberRequest);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task DeleteClassroom_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var id = 1;

            // Act
            var actionResult = await controller.DeleteClassroom(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GenerateClassroomCode_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var classroomId = 1;

            // Act
            var actionResult = await controller.GenerateClassroomCode(classroomId);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetAllClassroomCodes_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var classroomId = 1;

            // Act
            var actionResult = await controller.GetAllClassroomCodes(classroomId);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task JoinClassroomWithCode_ReturnsOk()
        {
            // Arrange
            var fakeClassroomService = A.Fake<IClassroomService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new ClassroomsController(fakeClassroomService);
            controller.SetFakeAccount(fakeAccount);
            var classroomCode = "ABC123";

            // Act
            var actionResult = await controller.JoinClassroomWithCode(classroomCode);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }
    }

    public static class ControllerExtensions
    {
        public static void SetFakeAccount(this ControllerBase controller, Account fakeAccount)
        {
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount }
                }
            };
        }
    }
}
