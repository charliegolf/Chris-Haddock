
namespace Haddock.Web.Modules
{
    using Haddock.Core;
    using Haddock.Web.ViewModels;
    using Nancy;

    /// <summary>
    /// Report module handles creation of full list of sessions (and later, filtering).
    /// </summary>
    public class SessionReportModule : NancyModule
    {
        private ISessionRepository _sessionRepo;
        private ITeamRepository _teamRepo;

        public SessionReportModule(ISessionRepository sessionRepository, ITeamRepository teamRepository)
            : base("/sessions")
        {
            this._sessionRepo = sessionRepository;
            this._teamRepo = teamRepository;

            // Returns list of all available sessions.
            Get["/"] = p => 
            {
                var detailedList = this._sessionRepo.ListSessions();

                var model = SessionInfoViewModel.CreateFrom(detailedList);

                return View["sessionlist.cshtml", model];
            };

            // Read-only session info.
            Get["/{id}"] = p => 
            {
                SessionDetail detail = this._sessionRepo.GetSession(p.id);

                var model = SessionInfoViewModel.CreateFrom(detail);

                return View["session.cshtml", model];
            };
        }
    }
}