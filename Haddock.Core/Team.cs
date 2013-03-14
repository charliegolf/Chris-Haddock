
namespace Haddock.Core
{
    /// <summary>
    /// Simple POCO representing a named team.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Db Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the team.
        /// </summary>
        public string Name { get; set; }
    }
}
