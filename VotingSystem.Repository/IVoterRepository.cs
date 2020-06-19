using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Models;

namespace VotingSystem.Contract
{
    public interface IVoterRepository : IRepository<Voters>
    {
        IEnumerable<Voters> GetVoters();
        //IEnumerable<Voter> GetVoters();
    }
}
