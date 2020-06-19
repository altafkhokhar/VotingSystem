using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.Contract.Services
{
    public interface ICandidateService :IBaseService<Candidates>
    {
        public int RegisterCandidate(CandidateDTO newCandidate);
        public bool AddCandidateToCategory(int categoryId, int peopleId);
        public dynamic GetVotesOfCandidate(int candidateId);
    }
}
