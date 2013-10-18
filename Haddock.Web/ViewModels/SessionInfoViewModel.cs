
namespace Haddock.Web.ViewModels
{
    using Haddock.Core;
    using System.Collections.Generic;
    using System;

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

        public string Setup { get; set; }

        public string InheritedRisk { get; set; }

        public string RisksToMitigate { get; set; }

        public string Tasks { get; set; }

        public string Bugs { get; set; }

        public string Issues { get; set; }

        public string Notes { get; set; }

        public string Handover { get; set; }

        public  string Date { get; set; }

        public string Duration { get; set; }
        
        public Boolean Cloud { get; set; }

        public Boolean OnPremise { get; set; }
     
        public Object Attachments { get; set; }

             

        public static SessionInfoViewModel CreateFrom(SessionDetail detail)
        {
            return new SessionInfoViewModel
            {
                Id = detail.Id,
                Team = detail.Team,
                Iteration = detail.Iteration,
                Area = detail.Area,
                Tester = detail.Tester,
                Mission = detail.Mission,
                Setup = detail.Setup,
                InheritedRisk = detail.InheritedRisk,
                RisksToMitigate = detail.RisksToMitigate,
                Tasks = detail.Tasks,
                Bugs = detail.Bugs,
                Issues = detail.Issues,
                Notes = detail.Notes,
                Handover = detail.Handover,
                Date = detail.Date,
                Duration = detail.Duration,
                Cloud = detail.Cloud,
                OnPremise = detail.OnPremise,
                Attachments = detail.Attachments
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