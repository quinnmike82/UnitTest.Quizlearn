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
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Services;

namespace UnitTest.Quizlearn
{
    public class SearchControllerTests
    {
        [Fact]
        public async Task GetAllPosts_ReturnsOk()
        {
            // Arrange
            var fakeSearchService = A.Fake<ISearchTextService>();
            var fakeAccount = A.Fake<Account>(); // If Account is used in the search service
            var controller = new SearchController(fakeSearchService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Items["Account"] = fakeAccount; // If Account is used in the controller
            var options = new PagedRequest { Search = "your_search_query", Take = 10 }; // Set up search query

            // Act
            var actionResult = await controller.GetAllPosts(options);

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<ActionResult<Dictionary<string, List<object>>>>(actionResult);
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var response = result.Value as Dictionary<string, List<object>>;
            Assert.NotNull(response);
            // Add more assertions as needed
        }
    }
}
