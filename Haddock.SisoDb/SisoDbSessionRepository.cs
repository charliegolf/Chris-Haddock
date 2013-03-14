
namespace Haddock.SisoDb
{
    using Haddock.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SisoDbSessionRepository : ISessionRepository
    {
        public IEnumerable<SessionDetail> ListSessions()
        {
            throw new NotImplementedException();
        }

        public SessionDetail GetSession(int dbKey)
        {
            throw new NotImplementedException();
        }

        public int AddSession(SessionDetail detail)
        {
            throw new NotImplementedException();
        }

        public void UpdateSession(SessionDetail detail)
        {
            throw new NotImplementedException();
        }
    }
}
