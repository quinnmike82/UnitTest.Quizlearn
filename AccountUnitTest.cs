using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Helpers;
using fuquizlearn_api.Models.Accounts;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;


namespace UnitTest.Quizlearn
{
    public class AccountUnitTest
    {
        [Fact]
        public async void ResetPasswordAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            var model = A.Fake<PagedRequest>();
            var actionResult = await controller.GetAllAsync(model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetbanAccount()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            var model = A.Fake<PagedRequest>();
            var actionResult = await controller.GetbanAccount(model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetByIdAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            var model = 1;
            var actionResult = await controller.GetByIdAsync(model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void CreateAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            var model = A.Fake<CreateRequest>();
            var actionResult = await controller.CreateAsync(model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void UpdateAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            var model = A.Fake<UpdateRequest>();
            Assert.ThrowsAsync<AppException>(async () => await controller.UpdateAsync(9999, model));
        }

        [Fact]
        public async void ChangePassword()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            var model = A.Fake<ChangePassRequest>();
            Assert.ThrowsAsync<AppException>(async () => await controller.ChangePassword(model));
        }

        [Fact]
        public async void DeleteAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            var actionResult = await controller.DeleteAsync(1);
            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void BanAccountAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            Assert.ThrowsAsync<AppException>(async () => await controller.BanAccountAsync(9999));
        }

        [Fact]
        public async void UnbanAccountAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            Assert.ThrowsAsync<AppException>(async () => await controller.UnbanAccountAsync(9999)); ;
        }

        [Fact]
        public async void WarningAccountAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            Assert.ThrowsAsync<AppException>(async () => await controller.WarningAccountAsync(9999));
        }

        [Fact]
        public async void GetUserProfileAsync()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AccountsController(data);
            Assert.ThrowsAsync<AppException>(async () => await controller.GetUserProfileAsync());
        }
    }
}
