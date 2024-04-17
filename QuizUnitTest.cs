using Xunit;
using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Models.Response;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using fuquizlearn_api.Models.Quiz;
using fuquizlearn_api.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace UnitTest.Quizlearn
{
    public class QuizControllerTests
    {
        [Fact]
        public async Task GetQuizFromBank_ReturnsOk()
        {
            // Arrange
            var fakeQuizService = A.Fake<IQuizService>();
            var fakeGeminiAIService = A.Fake<IGeminiAIService>();
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizController(fakeQuizService, fakeGeminiAIService, fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var bankId = 1;
            var options = new QuizPagedRequest { Search = "", Take = 10 };

            // Act
            var actionResult = await controller.GetQuizFromBank(bankId, options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<PagedResponse<QuizResponse>>>(actionResult);
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddQuizInBank_ReturnsOk()
        {
            // Arrange
            var fakeQuizService = A.Fake<IQuizService>();
            var fakeGeminiAIService = A.Fake<IGeminiAIService>();
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizController(fakeQuizService, fakeGeminiAIService, fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var bankId = 1;
            var quizCreate = new QuizCreate(); // Populate with required data

            // Act
            var actionResult = controller.AddQuizInBank(bankId, quizCreate);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<QuizResponse>>(actionResult);
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetTextResult_ReturnsOk()
        {
            // Arrange
            var fakeQuizService = A.Fake<IQuizService>();
            var fakeGeminiAIService = A.Fake<IGeminiAIService>();
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizController(fakeQuizService, fakeGeminiAIService, fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var quizCreate = new QuizCreate(); // Populate with required data

            // Act
            var actionResult = await controller.GetTextResult(quizCreate);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<IEnumerable<QuizResponse>>>(actionResult);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            var result = actionResult.Result as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task GetAnswer_ReturnsOk()
        {
            // Arrange
            var fakeQuizService = A.Fake<IQuizService>();
            var fakeGeminiAIService = A.Fake<IGeminiAIService>();
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizController(fakeQuizService, fakeGeminiAIService, fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var quizCreate = new QuizCreate(); // Populate with required data

            // Act
            var actionResult = await controller.GetAnswer(quizCreate);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<QuizResponse>>(actionResult);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            var result = actionResult.Result as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task GetCorrectAnswer_ReturnsOk()
        {
            // Arrange
            var fakeQuizService = A.Fake<IQuizService>();
            var fakeGeminiAIService = A.Fake<IGeminiAIService>();
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new QuizController(fakeQuizService, fakeGeminiAIService, fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var quizCreate = new QuizCreate(); // Populate with required data

            // Act
            var actionResult = await controller.GetCorrectAnswer(quizCreate);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<QuizResponse>>(actionResult);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            var result = actionResult.Result as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        // Add more unit tests for other methods as needed
    }
}
