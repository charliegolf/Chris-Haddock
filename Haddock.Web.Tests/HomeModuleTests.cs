
namespace Haddock.Web.Tests
{
    using Haddock.Web.Modules;
    using Nancy.Testing;
    using Xunit;

    public class HomeModuleTests
    {
        [Fact]
        public void Root_Redirects_To_Session_Root()
        {
            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Module<HomeModule>();
            });

            var browser = new Browser(bootstrapper); 

            var response = browser.Get("/");

            response.ShouldHaveRedirectedTo("/sessions/");
        }
    }
}
