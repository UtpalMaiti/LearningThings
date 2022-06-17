using System.Threading.Tasks;
using ReactSPA6_ALL.Models.TokenAuth;
using ReactSPA6_ALL.Web.Controllers;
using Shouldly;
using Xunit;

namespace ReactSPA6_ALL.Web.Tests.Controllers
{
    public class HomeController_Tests: ReactSPA6_ALLWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}