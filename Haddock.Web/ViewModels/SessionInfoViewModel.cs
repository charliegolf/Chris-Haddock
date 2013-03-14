
namespace Haddock.Web.ViewModels
{
    using Haddock.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Bare bones view of session. Used in session lists.
    /// </summary>
    public class SessionInfoViewModel
    {
        public int Id { get; set; }

        public string Team { get; set; }

        public string Iteration { get; set; }

        public string Area { get; set; }

        public string Tester { get; set; }

        public string Mission { get; set; }

        public static SessionInfoViewModel CreateFrom(SessionDetail detail)
        {
            return new SessionInfoViewModel
            {
                Id = detail.Id,
                Team = detail.Team,
                Iteration = detail.Iteration,
                Area = detail.Area,
                Tester = detail.Tester,
                Mission = detail.Mission
                // should add date.
            };
        }

        public static IEnumerable<SessionInfoViewModel> CreateFrom(IEnumerable<SessionDetail> details)
        {
            List<SessionInfoViewModel> model = new List<SessionInfoViewModel>();

            foreach (var detail in details)
            {
                model.Add(SessionInfoViewModel.CreateFrom(detail));
            }

            return model;
        }

    }
}