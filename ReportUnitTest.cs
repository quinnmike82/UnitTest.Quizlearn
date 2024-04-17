using Xunit;
using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Models.Response;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using fuquizlearn_api.Entities;
using fuquizlearn_api.Models.Report;
using Microsoft.AspNetCore.Http;

namespace UnitTest.Quizlearn
{
    public class ReportControllerTests
    {
        [Fact]
        public async Task GetAllReports_ReturnsOk()
        {
            // Arrange
            var fakeReportService = A.Fake<IReportService>();
            var fakeAccount = A.Fake<Account>(); // If Account is used in the report service
            var controller = new ReportController(fakeReportService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount; // If Account is used in the controller
            var options = new PagedRequest { Search = "", Take = 10 }; // Set up options

            // Act
            var actionResult = await controller.GetAllReports(options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<PagedResponse<ReportResponse>>>(actionResult);
            var result = actionResult.Result as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
            var response = result.Value as PagedResponse<ReportResponse>;
            Assert.NotNull(response);
            // Add more assertions as needed
        }

        [Fact]
        public async Task AddReport_ReturnsOk()
        {
            // Arrange
            var fakeReportService = A.Fake<IReportService>();
            var fakeAccount = A.Fake<Account>(); // If Account is used in the report service
            var controller = new ReportController(fakeReportService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount; // If Account is used in the controller
            var report = new ReportCreate(); // Populate with required data

            // Act
            var actionResult = await controller.GetAllReports(report);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<ReportResponse>>(actionResult);
            var result = actionResult.Result as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
            var response = result.Value as ReportResponse;
            Assert.NotNull(response);
            // Add more assertions as needed
        }

        [Fact]
        public async Task VerifyReport_ReturnsOk()
        {
            // Arrange
            var fakeReportService = A.Fake<IReportService>();
            var fakeAccount = A.Fake<Account>(); // If Account is used in the report service
            var controller = new ReportController(fakeReportService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount; // If Account is used in the controller
            var reportId = 1; // Specify report ID here

            // Act
            var actionResult = await controller.VerifyReport(reportId);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
            var result = actionResult as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var message = result.Value as string;
            Assert.NotNull(message);
            Assert.Equal("Report.Verify", message);
            // Add more assertions as needed
        }

        [Fact]
        public async Task DeleteReport_ReturnsOk()
        {
            // Arrange
            var fakeReportService = A.Fake<IReportService>();
            var fakeAccount = A.Fake<Account>(); // If Account is used in the report service
            var controller = new ReportController(fakeReportService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount; // If Account is used in the controller
            var reportDelete = new ReportDelete(); // Populate with required data

            // Act
            var actionResult = await controller.DeleteReport(reportDelete);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkResult>(actionResult);
            var result = actionResult as OkResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            // Add more assertions as needed
        }

        // Add tests for other endpoints similarly...
    }
}
