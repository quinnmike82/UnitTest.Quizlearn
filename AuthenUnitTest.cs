using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Helpers;
using fuquizlearn_api.Models.Accounts;
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
            Assert.ThrowsAsync<AppException>(async () => await controller.AuthenticateAsync(model));
        }

        [Fact]
        public async void Authen_Register()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AuthController(data);
            var model = A.Fake<RegisterRequest>();
            var actionResult = await controller.RegisterAsync(model);
            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void Login_Google()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AuthController(data);
            var model = A.Fake<LoginGoogleRequest>();
            Assert.ThrowsAsync<AppException>(async () => await controller.GoogleAuthenticateAsync(model));
        }

        [Fact]
        public async void RefreshToken()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AuthController(data);
            var model = "INVALIDTOKEN";
            Assert.ThrowsAsync<AppException>(async () => await controller.RefreshTokenAsync(model));
        }

        [Fact]
        public async void RevokeTokenAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AuthController(data);
            var model = A.Fake<RevokeTokenRequest>();
            Assert.ThrowsAsync<AppException>(async () => await controller.RevokeTokenAsync(model));
        }

        [Fact]
        public async void VerifyEmailAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AuthController(data);
            var model = A.Fake<VerifyEmailRequest>();
            Assert.ThrowsAsync<AppException>(async () => await controller.VerifyEmailAsync(model));
        }

        [Fact]
        public async void ResetPasswordAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AuthController(data);
            var model = A.Fake<ResetPasswordRequest>();
            Assert.ThrowsAsync<AppException>(async () => await controller.ResetPasswordAsync(model));
        }
    }
}