
namespace Haddock.InMemory
{
    using Haddock.Core;
    using System.Collections.Generic;
    using System.Linq;

    public class InMemorySessionRepository : ISessionRepository
    {
        private List<SessionDetail> _sessions = new List<SessionDetail>();

        public IEnumerable<SessionDetail> ListSessions()
        {
            return this._sessions;
        }

        public SessionDetail GetSession(int dbKey)
        {
            return this._sessions.FirstOrDefault(s => s.Id == dbKey);
        }

        public int AddSession(SessionDetail detail)
        {
            int dbKey = this._sessions.Count + 1;
            detail.Id = dbKey;

            this._sessions.Add(detail);

            return dbKey;
        }

        public void UpdateSession(SessionDetail detail)
        {
            if (detail.Id <= 0)
                return;

            var existing = this._sessions.FirstOrDefault(d => d.Id == detail.Id);

            if (existing != null)
            {
                existing.Area = detail.Area;
                existing.Iteration = detail.Iteration;
                existing.Mission = detail.Mission;
                existing.Team = detail.Team;
                existing.Tester = detail.Tester;
            }
        }

    }
}
