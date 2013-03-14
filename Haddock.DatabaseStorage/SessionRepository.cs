
namespace Haddock.DatabaseStorage
{
    using Haddock.Core;
    using SisoDb;
    using SisoDb.Sql2012;
    using SisoDb.SqlServer;
    using System.Collections.Generic;

    public class SessionRepository : IDatabaseSessionRepository
    {
        private ISisoDatabase _database;
                
        public IEnumerable<SessionDetail> ListSessions()
        {
            return this.Instance.UseOnceTo()
                .Query<SessionDetail>()
                .ToList();
        }

        public SessionDetail GetSession(int dbKey)
        {
            return this.Instance.UseOnceTo()
                .Query<SessionDetail>()
                .Where(d => d.Id == dbKey).FirstOrDefault();
        }

        public int AddSession(SessionDetail detail)
        {
            this.Instance.UseOnceTo()
                .Insert(detail);

            return detail.Id;
        }

        public void UpdateSession(SessionDetail detail)
        {
            this.Instance.UseOnceTo()
                .Update(detail);
        }

        private ISisoDatabase Instance
        {
            get
            {
                if (_database == null)
                {
                    SqlServerConnectionInfo connectionInfo = new Sql2012ConnectionInfo(ConnectionString);
                    ISisoDatabase db = new Sql2012DbFactory().CreateDatabase(connectionInfo);

                    if (db != null)
                    {
                        db.CreateIfNotExists(); 
                    }

                    _database = db;
                }

                return _database;
            }
        }

        public string ConnectionString { get; set; }
    }
}
