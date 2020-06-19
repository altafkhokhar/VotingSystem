using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Contract;
using VotingSystem.Models;

namespace VotingSystem.Repository
{
    public class CandidateRepository : Repository<Candidates>, ICandidateRepository
    {
        public VotingDBContext ApplicationDatabaseContext
        {
            get { return DatabaseContext as VotingDBContext; }
        }

        public CandidateRepository(VotingDBContext context) : base(context) { }
    }
}
