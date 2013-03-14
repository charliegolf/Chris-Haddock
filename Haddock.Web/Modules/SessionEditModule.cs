
namespace Haddock.Web.Modules
{
    using Haddock.Core;
    using Haddock.Web.ViewModels;
    using Nancy;
    using Nancy.ModelBinding;
    using System;

    /// <summary>
    /// Session module used to create and edit sessions.
    /// </summary>
    public class SessionEditModule : NancyModule
    {
        private ISessionRepository _sessionRepo;
        private ITeamRepository _teamRepo;

        public SessionEditModule(ISessionRepository sessionRepository, ITeamRepository teamRepository)
            : base("/session")
        {
            this._sessionRepo = sessionRepository;
            this._teamRepo = teamRepository;

            // Create a new module - return an empty form.
            Get["/new/"] = p =>
            {
                var model = SessionEditViewModel.CreateFrom(this._teamRepo);

                model.Started = DateTime.Now;

                return View["newsession.cshtml", model];
            };

            // Save a new session and redirect to the edit page.
            Post["/new/"] = p =>
            {
                var model = this.Bind<SessionEditViewModel>("Id");

                var session = model.ToDetail(this._teamRepo);

                int dbKey = this._sessionRepo.AddSession(session);

                return Response.AsRedirect(string.Format("/session/edit/{0}", dbKey));
            };

            // Get an edit page for this session.
            Get["/edit/{id}"] = p =>
            {
                SessionDetail detail = this._sessionRepo.GetSession(p.id);
                
                var model = SessionEditViewModel.CreateFrom(this._teamRepo, detail);

                return View["editsession.cshtml", model];
            };

            // Update a session. Redirect back to edit.
            Post["/edit/{id}"] = p =>
            {
                var model = this.Bind<SessionEditViewModel>();

                var detail = model.ToDetail(this._teamRepo);

                if (detail != null)
                {
                    this._sessionRepo.UpdateSession(detail);
   
                    return Response.AsRedirect(string.Format("/session/edit/{0}", detail.Id));
                }

                return Response.AsRedirect("/sessions/");
            };
        }
    }
}