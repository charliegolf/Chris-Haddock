
namespace Haddock.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Holds test session info.
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        /// All sessions.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SessionDetail> ListSessions();

        /// <summary>
        /// Individual session (by db key).
        /// </summary>
        /// <param name="dbKey"></param>
        /// <returns></returns>
        SessionDetail GetSession(int dbKey);

        /// <summary>
        /// Create a session.
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        int AddSession(SessionDetail detail);

        /// <summary>
        /// Update Individual session (by db key).
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        void UpdateSession(SessionDetail detail);
    }
}
