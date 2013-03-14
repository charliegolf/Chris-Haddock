
namespace Haddock.Web
{
    using Haddock.Core;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Elmah;
    using Nancy.TinyIoc;
    using System.Configuration;
    using System.Web.Configuration;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            // attempt to set up the connection string to database repos.
            ISessionRepository sessionRepo = container.Resolve<ISessionRepository>();
            IDatabaseSessionRepository dbRepo = sessionRepo as IDatabaseSessionRepository;

            if (dbRepo != null)
            {
                Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("~");
                KeyValueConfigurationElement cs = webConfig.AppSettings.Settings["ConnectionString"];

                if (cs != null)
                {
                    dbRepo.ConnectionString = cs.Value;
                }
            }

            Elmahlogging.Enable(pipelines, "elmah", new string[0], new HttpStatusCode[] { HttpStatusCode.NotFound, HttpStatusCode.InsufficientStorage, });
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ITeamRepository, Haddock.InMemory.InMemoryTeamRepository>().AsSingleton();
            container.Register<ISessionRepository, Haddock.DatabaseStorage.SessionRepository>().AsSingleton();
        }
    }
}