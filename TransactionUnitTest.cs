using Xunit;
using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Models.Response;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using fuquizlearn_api.Models.Transaction;
using fuquizlearn_api.Entities;
using Microsoft.AspNetCore.Http;
using Xunit.Abstractions;

namespace UnitTest.Quizlearn
{
    public class TransactionControllerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TransactionControllerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public async Task GetAll_WithMonth_ReturnsOk()
        {
            // Arrange
            var fakeTransactionService = A.Fake<ITransactionService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new TransactionController(fakeTransactionService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var month = 1;
            var options = new PagedRequest { Search = "", Take = 10 };

            // Act
            var actionResult = await controller.GetAll(month, options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Result); // Check if action result is not null

            // Additional logging for debugging
            Console.WriteLine($"Action Result: {actionResult}");
            Console.WriteLine($"Action Result Result: {actionResult.Result}");

            Assert.IsType<ActionResult<PagedResponse<TransactionResponse>>>(actionResult);
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetAll_WithoutMonth_ReturnsOk()
        {
            // Arrange
            var fakeTransactionService = A.Fake<ITransactionService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new TransactionController(fakeTransactionService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var options = new PagedRequest { Search = "", Take = 10 };

            // Act
            var actionResult = await controller.GetAll(options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<PagedResponse<TransactionResponse>>>(actionResult);
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var response = result.Value as PagedResponse<TransactionResponse>;
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetChart_ReturnsOk()
        {
            // Arrange
            var fakeTransactionService = A.Fake<ITransactionService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new TransactionController(fakeTransactionService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var year = 2024; // Specify year here

            // Act
            var actionResult = await controller.GetChart(year);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<List<ChartTransaction>>>(actionResult);
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var response = result.Value as List<ChartTransaction>;
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetAllCurrent_ReturnsOk()
        {
            // Arrange
            var fakeTransactionService = A.Fake<ITransactionService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new TransactionController(fakeTransactionService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var options = new PagedRequest { Search = "", Take = 10 };

            // Act
            var actionResult = await controller.GetAllCurrent(options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<PagedResponse<TransactionResponse>>>(actionResult);
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var response = result.Value as PagedResponse<TransactionResponse>;
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Create_ReturnsOk()
        {
            // Arrange
            var fakeTransactionService = A.Fake<ITransactionService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new TransactionController(fakeTransactionService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount;
            var transaction = new TransactionCreate(); // Populate with required data

            // Act
            var actionResult = await controller.Create(transaction);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<TransactionResponse>>(actionResult);
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var response = result.Value as TransactionResponse;
            Assert.NotNull(response);
        }


    }
}
