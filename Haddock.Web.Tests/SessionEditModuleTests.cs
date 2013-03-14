
namespace Haddock.Web.Tests
{
    using Haddock.Core;
    using Haddock.Web.Modules;
    using Nancy;
    using Nancy.Testing;
    using NSubstitute;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xunit;
    
    public class SessionEditModuleTests
    {
        [Fact]
        public void Get_Session_New_Returns_Empty_Form()
        {
            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Module<SessionEditModule>();
                with.Dependency<ITeamRepository>(Substitute.For<ITeamRepository>());
                with.Dependency<ISessionRepository>(Substitute.For<ISessionRepository>());
            });

            var browser = new Browser(bootstrapper);

            var response = browser.Get("/session/new/");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // need to check content...
        }

        [Fact]
        public void Post_Session_New_Redirects_To_Edit_Page()
        {
            ISessionRepository sessionRepo = Substitute.For<ISessionRepository>();
            sessionRepo.AddSession(Arg.Any<SessionDetail>()).Returns(99);

            ITeamRepository teamRepo = Substitute.For<ITeamRepository>();
            teamRepo.ListIterations().Returns(new ReadOnlyCollection<Iteration>(new List<Iteration>()));
            teamRepo.ListProductAreas().Returns(new ReadOnlyCollection<ProductArea>(new List<ProductArea>()));
            teamRepo.ListTeams().Returns(new ReadOnlyCollection<Team>(new List<Team>()));
            teamRepo.ListTesters().Returns(new ReadOnlyCollection<Tester>(new List<Tester>()));

            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Module<SessionEditModule>();
                with.Dependency<ITeamRepository>(teamRepo);
                with.Dependency<ISessionRepository>(sessionRepo);
            });

            var browser = new Browser(bootstrapper);

            var response = browser.Post("/session/new/", with =>
                {
                    with.HttpRequest();
                    with.FormValue("TeamId",        "1");
                    with.FormValue("IterationId",   "2");
                    with.FormValue("ProductAreaId", "3");
                    with.FormValue("TesterId",      "4");
                    with.FormValue("Mission",       "To Seek Out New Life...");
                });

            response.ShouldHaveRedirectedTo("/session/edit/99");
        }

    }
}
