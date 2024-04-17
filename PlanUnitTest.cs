using Xunit;
using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Models.Plan;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using fuquizlearn_api.Entities;
using Microsoft.AspNetCore.Http;

namespace UnitTest.Quizlearn
{
    public class PlanControllerTests
    {
        [Fact]
        public async Task CreatePlan_ReturnsOk()
        {
            // Arrange
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PlanController(fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var planCreate = new PlanCreate();

            // Act
            var actionResult = await controller.CreatePlan(planCreate);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task RegistPlan_ReturnsOk()
        {
            // Arrange
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PlanController(fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var id = 1;
            var transactionId = "transaction123";

            // Act
            var actionResult = await controller.RegistPlan(id, transactionId);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetAllPlans_ReturnsOk()
        {
            // Arrange
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PlanController(fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };

            // Act
            var actionResult = await controller.GetAllPlans();

            // Assert
            Assert.IsType<ActionResult<List<PlanResponse>>>(actionResult);
        }

        [Fact]
        public async Task RemovePlan_ReturnsNoContent()
        {
            // Arrange
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PlanController(fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var id = 1;

            // Act
            var actionResult = await controller.RemovePlan(id);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task UnReleasePlan_ReturnsOk()
        {
            // Arrange
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PlanController(fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var id = 1;

            // Act
            var actionResult = await controller.UnReleasePlan(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task UpdatePlan_ReturnsOk()
        {
            // Arrange
            var fakePlanService = A.Fake<IPlanService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PlanController(fakePlanService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var planUpdate = new PlanUpdate();

            // Act
            var actionResult = await controller.UpdatePlan(planUpdate);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }
    }
}
