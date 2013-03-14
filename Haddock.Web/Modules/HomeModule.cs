
namespace Haddock.Web.Modules
{
    using Nancy;

    /// <summary>
    /// Home module.
    /// </summary>
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            // access to index gives you back a 
            // list of the current sessions.
            Get["/"] = _ =>
            {
                return Response.AsRedirect("/sessions/");
            };
        }
    }
}