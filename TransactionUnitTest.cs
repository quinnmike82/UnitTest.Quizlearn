using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Quizlearn
{

    public class TransactionUnitTest
    {
        [Fact]
        public async void GetMonth_UnitTest()
        {
            var data = A.Fake<IAccountService>();
            var controller = new AuthController(data);
            AuthenticateRequest model = A.Fake<AuthenticateRequest>();
            var actionResult = await controller.AuthenticateAsync(model);
            var result = actionResult.Result as OkObjectResult;
            Assert.Equal(result.StatusCode, 200);
        }
        
    }
}
