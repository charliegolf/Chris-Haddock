
namespace Haddock.Core
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Used to get team specific information from a bug tracker, project management tool etc.
    /// </summary>
    public interface ITeamRepository
    {
        /// <summary>
        /// All iterations.
        /// </summary>
        /// <returns></returns>
        ReadOnlyCollection<Iteration> ListIterations();

        /// <summary>
        /// All product areas.
        /// </summary>
        /// <returns></returns>
        ReadOnlyCollection<ProductArea> ListProductAreas();

        /// <summary>
        /// All teams.
        /// </summary>
        /// <returns></returns>
        ReadOnlyCollection<Team> ListTeams();

        /// <summary>
        /// All testers.
        /// </summary>
        /// <returns></returns>
        ReadOnlyCollection<Tester> ListTesters();
    }
}
