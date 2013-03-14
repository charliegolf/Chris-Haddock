
namespace Haddock.Web.ViewModels
{
    using Haddock.Core;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// View model used to create/edit session.
    /// </summary>
    public class SessionEditViewModel : SessionEditModel
    {

        public Team SelectedTeam { get; set; }

        /// <summary>
        /// List of available teams populated from the ITeamRepository.
        /// </summary>
        public ICollection<Team> AllTeams { get; set; }

        public Iteration SelectedIteration { get; set; }

        /// <summary>
        /// List of available iterations populated from the ITeamRepository.
        /// </summary>
        public ICollection<Iteration> AllIterations { get; set; }

        public ProductArea SelectedProductArea { get; set; }

        /// <summary>
        /// List of available product areas populated from the ITeamRepository.
        /// </summary>
        public ICollection<ProductArea> AllProductAreas { get; set; }

        public Tester SelectedTester { get; set; }

        /// <summary>
        /// List of available testers populated from the ITeamRepository.
        /// </summary>
        public ICollection<Tester> AllTesters { get; set; }

        public void SelectTeam(string teamName)
        {
            if (this.AllTeams != null && this.AllTeams.Any())
            {
                this.SelectedIteration = this.AllIterations.FirstOrDefault(
                    t => string.Compare(t.Name, teamName, false) == 0);
            }
        }

        public void SelectIteration(string iterName)
        {
            if (this.AllIterations != null && this.AllIterations.Any())
            {
                this.SelectedIteration = this.AllIterations.FirstOrDefault(
                    i => string.Compare(i.Name, iterName, false) == 0);
            }
        }

        public void SelectProductArea(string areaName)
        {
            if (this.AllProductAreas != null && this.AllProductAreas.Any())
            {
                this.SelectedProductArea = this.AllProductAreas.FirstOrDefault(
                    a => string.Compare(a.Name, areaName, false) == 0);
            }
        }

        public void SelectTester(string testerName)
        {
            if (this.AllTesters != null && this.AllTesters.Any())
            {
                this.SelectedTester = this.AllTesters.FirstOrDefault(
                    t => string.Compare(t.Name, testerName, false) == 0);
            }
        }

        /// <summary>
        /// Create a new instance will drop downs populated by the team repository.
        /// </summary>
        /// <param name="teamRepo"></param>
        /// <returns></returns>
        public static SessionEditViewModel CreateFrom(ITeamRepository teamRepo)
        {
            var model = new SessionEditViewModel();
            
            model.AllProductAreas = teamRepo.ListProductAreas();
            model.AllIterations = teamRepo.ListIterations();
            model.AllTeams = teamRepo.ListTeams();
            model.AllTesters = teamRepo.ListTesters();

            return model;
        }


        /// <summary>
        /// Create a new instance will drop downs populated by the team repository.
        /// </summary>
        /// <param name="teamRepo"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public static SessionEditViewModel CreateFrom(ITeamRepository teamRepo, SessionDetail detail)
        {
            if (detail == null)
                return new SessionEditViewModel();

            var model = new SessionEditViewModel()
            {
                Id = detail.Id,
                Bugs = detail.Bugs,
                Ended = detail.Ended,
                Handover = detail.Handover,
                Issues = detail.Issues,
                Mission = detail.Mission,
                Notes = detail.Notes,
                RisksToMitigate = detail.RisksToMitigate,
                Setup = detail.Setup,
                Started = detail.Started,
                Tasks = detail.Tasks
            };
              
            model.AllProductAreas = teamRepo.ListProductAreas();
            model.SelectProductArea(detail.Area);

            model.AllIterations = teamRepo.ListIterations();
            model.SelectIteration(detail.Iteration);

            model.AllTeams = teamRepo.ListTeams();
            model.SelectTeam(detail.Team);

            model.AllTesters = teamRepo.ListTesters();
            model.SelectTester(detail.Tester);

            return model;
        }

       
        /// <summary>
        /// Turn posted info from form back into something we can save in db.
        /// </summary>
        /// <param name="teamRepo"></param>
        /// <returns></returns>
        public SessionDetail ToDetail(ITeamRepository teamRepo)
        {
            var detail = new SessionDetail()
                {
                    Id = this.Id,
                    Bugs = this.Bugs,
                    Ended = this.Ended,
                    Handover = this.Handover,
                    Issues = this.Issues,
                    Notes = this.Notes,
                    Mission = this.Mission,
                    RisksToMitigate = this.RisksToMitigate,
                    Setup = this.Setup,
                    Started = this.Started,
                    Tasks = this.Tasks
                };

            var area = teamRepo.ListProductAreas().FirstOrDefault(a => a.Id == this.ProductAreaId);
            var iter = teamRepo.ListIterations().FirstOrDefault(i => i.Id == this.IterationId);
            var team = teamRepo.ListTeams().FirstOrDefault(t => t.Id == this.TeamId);
            var tester = teamRepo.ListTesters().FirstOrDefault(t => t.Id == this.TesterId);

            if (area != null)
            {
                detail.Area = area.Name;
            }

            if (iter != null)
            {
                detail.Iteration = iter.Name;
            }

            if (team != null)
            {
                detail.Team = team.Name;
            }

            if (tester != null)
            {
                detail.Tester = tester.Name;
            }

            return detail;
        }

    }
}