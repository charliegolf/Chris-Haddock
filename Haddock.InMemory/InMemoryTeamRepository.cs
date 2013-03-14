
namespace Haddock.InMemory
{
    using Haddock.Core;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class InMemoryTeamRepository : ITeamRepository
    {
        private List<ProductArea> _productAreas = new List<ProductArea>();
        private List<Iteration> _iterations = new List<Iteration>();
        private List<Team> _teams = new List<Team>();
        private List<Tester> _testers = new List<Tester>();

        public InMemoryTeamRepository()
        {
            int dbKey = 0;
            this._iterations.Add(new Iteration { Id = ++dbKey, Name = "First" });
            this._iterations.Add(new Iteration { Id = ++dbKey, Name = "Second" });
            this._iterations.Add(new Iteration { Id = ++dbKey, Name = "Third" });
            this._iterations.Add(new Iteration { Id = ++dbKey, Name = "Fourth" });
            this._iterations.Add(new Iteration { Id = ++dbKey, Name = "Fifth" });

            this._productAreas.Add(new ProductArea { Id = ++dbKey, Name = "User Interface" });
            this._productAreas.Add(new ProductArea { Id = ++dbKey, Name = "Database" });
            this._productAreas.Add(new ProductArea { Id = ++dbKey, Name = "Infrastructure" });
            this._productAreas.Add(new ProductArea { Id = ++dbKey, Name = "Business Logic" });
            this._productAreas.Add(new ProductArea { Id = ++dbKey, Name = "Web Interface" });
            this._productAreas.Add(new ProductArea { Id = ++dbKey, Name = "Mobile" });

            this._teams.Add(new Team { Id = ++dbKey, Name = "Phil's Team" });
            this._teams.Add(new Team { Id = ++dbKey, Name = "Mike's Team" });
            this._teams.Add(new Team { Id = ++dbKey, Name = "Neil's Team" });
            this._teams.Add(new Team { Id = ++dbKey, Name = "Michael's Team" });
            this._teams.Add(new Team { Id = ++dbKey, Name = "Mark's Team" });

            this._testers.Add(new Tester { Id = ++dbKey, Name = "Chris" });
            this._testers.Add(new Tester { Id = ++dbKey, Name = "David" });
            this._testers.Add(new Tester { Id = ++dbKey, Name = "Denise" });
            this._testers.Add(new Tester { Id = ++dbKey, Name = "Marc" });
            this._testers.Add(new Tester { Id = ++dbKey, Name = "Darren" });
            this._testers.Add(new Tester { Id = ++dbKey, Name = "Kaye" });
        }

        public ReadOnlyCollection<Iteration> ListIterations()
        {
            return new ReadOnlyCollection<Iteration>(this._iterations);
        }

        public ReadOnlyCollection<ProductArea> ListProductAreas()
        {
            return new ReadOnlyCollection<ProductArea>(this._productAreas);
        }

        public ReadOnlyCollection<Team> ListTeams()
        {
            return new ReadOnlyCollection<Team>(this._teams);
        }

        public ReadOnlyCollection<Tester> ListTesters()
        {
            return new ReadOnlyCollection<Tester>(this._testers);
        }
    }
}
