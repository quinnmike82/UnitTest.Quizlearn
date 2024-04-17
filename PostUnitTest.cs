using Xunit;
using FakeItEasy;
using fuquizlearn_api.Controllers;
using fuquizlearn_api.Models.Posts;
using fuquizlearn_api.Models.Request;
using fuquizlearn_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using fuquizlearn_api.Entities;
using Microsoft.AspNetCore.Http;

namespace UnitTest.Quizlearn
{
    public class PostControllerTests
    {
        [Fact]
        public async Task CreatePost_ReturnsCreatedAtAction()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PostController(fakePostService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var postCreate = new PostCreate();

            // Act
            var actionResult = await controller.CreatePost(postCreate);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            Assert.Equal(nameof(PostController.GetPostById), createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task GetPostById_ReturnsOk()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var controller = new PostController(fakePostService);
            var id = 1;

            // Act
            var actionResult = await controller.GetPostById(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetAllPosts_ReturnsOk()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var controller = new PostController(fakePostService);
            var classroomId = 1;
            var options = new PagedRequest();

            // Act
            var actionResult = await controller.GetAllPosts(classroomId, options);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task DeletePost_ReturnsNoContent()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var controller = new PostController(fakePostService);
            var id = 1;

            // Act
            var actionResult = await controller.DeletePost(id);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task AddView_ReturnsOk()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PostController(fakePostService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var id = 1;

            // Act
            var actionResult = await controller.AddView(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetAccountView_ReturnsOk()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var controller = new PostController(fakePostService);
            var id = 1;
            var options = new PagedRequest();

            // Act
            var actionResult = await controller.GetAccountView(id, options);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task UpdatePost_ReturnsOk()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PostController(fakePostService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var id = 1;
            var postUpdate = new PostUpdate();

            // Act
            var actionResult = await controller.UpdatePost(id, postUpdate);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task CreateComment_ReturnsCreatedAtAction()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var fakeAccount = A.Fake<Account>();
            var controller = new PostController(fakePostService);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = { ["Account"] = fakeAccount } // Fake the Account object
                }
            };
            var postId = 1;
            var commentCreate = new CommentCreate();

            // Act
            var actionResult = await controller.CreateComment(postId, commentCreate);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            Assert.Equal(nameof(PostController.GetCommentById), createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task GetCommentById_ReturnsOk()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var controller = new PostController(fakePostService);
            var id = 1;

            // Act
            var actionResult = await controller.GetCommentById(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task DeleteComment_ReturnsNoContent()
        {
            // Arrange
            var fakePostService = A.Fake<IPostService>();
            var controller = new PostController(fakePostService);
            var id = 1;

            // Act
            var actionResult = await controller.DeleteComment(id);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }
    }
}
