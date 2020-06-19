using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Contract;
using VotingSystem.Models;

namespace VotingSystem.Repository
{
    public class PeopleRepository : Repository<People>, IPeopleRepository
    {
        public VotingDBContext ApplicationDatabaseContext
        {
            get { return DatabaseContext as VotingDBContext; }
        }
        public PeopleRepository(VotingDBContext context) : base(context) { }
    }
}
