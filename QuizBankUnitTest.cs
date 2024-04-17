using Xunit;
using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Models.QuizBank;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Models.Response;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using fuquizlearn_api.Entities;
using Microsoft.AspNetCore.Http;

namespace UnitTest.Quizlearn
{
    public class QuizBankControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var options = new PagedRequest { Search = "", Take = 10 };

            // Act
            var actionResult = await controller.GetAll(options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<PagedResponse<QuizBankResponse>>>(actionResult);
        }

        [Fact]
        public async Task GetBySubject_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var tag = "example";
            var options = new PagedRequest { Search = "", Take = 10 };

            // Act
            var actionResult = await controller.GetBySubject(tag, options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<PagedResponse<QuizBankResponse>>>(actionResult);
        }

        [Fact]
        public async Task GetMy_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var options = new PagedRequest { Search = "", Take = 10 };

            // Act
            var actionResult = await controller.GetMy(options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<PagedResponse<QuizBankResponse>>>(actionResult);
        }

        // Add similar tests for other methods

        [Fact]
        public async Task GetById_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var id = 1;

            // Act
            var actionResult = await controller.GetById(id);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<QuizBankResponse>>(actionResult);
        }

        [Fact]
        public async Task Create_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var model = new QuizBankCreate();

            // Act
            var actionResult = await controller.Create(model);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<QuizBankResponse>>(actionResult);
        }

        // Add tests for other methods

        [Fact]
        public async Task RatingAsync_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var id = 1;
            var rating = new RatingRequest { Star = 5 };

            // Act
            var actionResult = await controller.RatingAsync(id, rating);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<QuizBankResponse>>(actionResult);
        }


        [Fact]
        public async Task UpdateAsync_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var id = 1;
            var model = new QuizBankUpdate();

            // Act
            var actionResult = await controller.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<QuizBankResponse>>(actionResult);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var id = 1;

            // Act
            var actionResult = await controller.DeleteAsync(id);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetRelated_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var controller = new QuizBankController(fakeQuizBankService);
            var id = 1;

            // Act
            var actionResult = await controller.GetRelated(id);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<IEnumerable<QuizBankResponse>>>(actionResult);
        }

        // Add tests for other methods...

        [Fact]
        public async Task SaveProgress_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var quizbankId = 1;
            var saveProgressRequest = new SaveProgressRequest();

            // Act
            var actionResult = await controller.SaveProgress(quizbankId, saveProgressRequest);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<ProgressResponse>>(actionResult);
        }

        [Fact]
        public async Task GetProgress_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var quizbankId = 1;

            // Act
            var actionResult = await controller.GetProgress(quizbankId);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<ProgressResponse>>(actionResult);
        }

        [Fact]
        public async Task CopyQuizBank_ReturnsOk()
        {
            // Arrange
            var fakeQuizBankService = A.Fake<IQuizBankService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizBankController(fakeQuizBankService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var quizbankId = 1;
            var quizBankUpdate = new QuizBankUpdate();

            // Act
            var actionResult = await controller.CopyQuizBank(quizBankUpdate, quizbankId);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<QuizBankResponse>>(actionResult);
        }
    }
}
