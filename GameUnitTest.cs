using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Entities;
using fuquizlearn_api.Helpers;
using fuquizlearn_api.Models.Classroom;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest.Quizlearn
{
    public class GameUnitTest
    {
        [Fact]
        public async void CreateAsync()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var model = A.Fake<GameCreate>();
            var actionResult = await controller.Create(model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void Join()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            Assert.ThrowsAsync<AppException>(async () => await controller.Join(9999));
        }

        [Fact]
        public async void GetAllByClassId()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var model = A.Fake<PagedRequest>();
            var actionResult = await controller.GetAllByClassId(1, model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetAllByQuizBankId()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var model = A.Fake<PagedRequest>();
            var actionResult = await controller.GetAllByQuizBankId(1, model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetMyJoined()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var model = A.Fake<PagedRequest>();
            var actionResult = await controller.GetMyJoined(model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetById()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var actionResult = await controller.GetById(1);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetQuizes()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var model = A.Fake<PagedRequest>();
            var actionResult = await controller.GetQuizes(1, model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void StartById()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var actionResult = await controller.StartById(1);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void EndById()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var actionResult = await controller.EndById(1);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void AddAnswerHistory()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var model = A.Fake<AnswerHistoryRequest>();
            var actionResult = await controller.AddAnswerHistory(model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void SubmitTest()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var model = A.CollectionOfFake<AnswerHistoryRequest>(3).ToArray();
            var actionResult = await controller.SubmitTest(1, model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetMyGameRecord()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            var acc = A.Fake<Account>();
            controller.SetFakeAccount(acc);
            var model = A.CollectionOfFake<AnswerHistoryRequest>(3).ToArray();
            var actionResult = await controller.GetMyGameRecord(1, acc.Id);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetAllGameRecord()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            controller.SetFakeAccount(A.Fake<Account>());
            var model = A.Fake<PagedRequest>();
            var actionResult = await controller.GetAllGameRecord(1, model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetUserAnswerHistory()
        {
            var data = A.Fake<IGameService>();
            var controller = new GameController(data);
            var acc = A.Fake<Account>();
            controller.SetFakeAccount(acc);
            var model = A.Fake<PagedRequest>();
            var actionResult = await controller.GetUserAnswerHistory(1,acc.Id, model);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
