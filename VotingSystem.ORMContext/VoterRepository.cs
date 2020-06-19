using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VotingSystem.Models;
using VotingSystem.Contract;

namespace VotingSystem.Repository
{
    public class VoterRepository : Repository<Voters> , IVoterRepository
    {
        public VotingDBContext ApplicationDatabaseContext
        {
            get { return DatabaseContext as VotingDBContext; }
        }

        public VoterRepository(VotingDBContext context) : base(context) { }

        public IEnumerable<Voters> GetVoters()
        {
            return ApplicationDatabaseContext.Voters.ToList();
        }


        //public IEnumerable<Voter> GetBooksByCurrentYear()
        //{
        //    return ApplicationDatabaseContext.Voters.Where(b => b.Date.Year >= DateTime.Now.Year).ToList();
        //}
    }
}
