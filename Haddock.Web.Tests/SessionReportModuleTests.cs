
namespace Haddock.Web.Tests
{
    using Haddock.Core;
    using Haddock.Web.Modules;
    using Nancy;
    using Nancy.Testing;
    using NSubstitute;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;
    
    public class SessionReportModuleTests
    {
        [Fact]
        public void Root_Shows_List_Of_Sessions()
        {
            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Module<SessionReportModule>();
                with.Dependency<ITeamRepository>(Substitute.For<ITeamRepository>());
                with.Dependency<ISessionRepository>(Substitute.For<ISessionRepository>());
            });

            var browser = new Browser(bootstrapper);

            var response = browser.Get("/sessions/");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
