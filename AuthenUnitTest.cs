using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Models.Accounts;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest.Quizlearn
{
    public class AuthenUnitTest
    {
        [Fact]
        public async void Authen_Login()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AuthController(data);
            AuthenticateRequest model = A.Fake<AuthenticateRequest>();
            var actionResult = await controller.AuthenticateAsync(model);
            var result = actionResult.Result as OkObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }

        [Fact]
        public async void Authen_Register()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            int model = 3;
            var actionResult = await controller.GetByIdAsync(model);
            var result = actionResult.Result as OkObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
    }
}