using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.Contract.Services
{
    public interface ICandidateService :IBaseService<Candidate>
    {
        public bool TryRegisterCandidate(ref CandidateDTO newCandidate);
        public int TryAddCandidateToCategory(int categoryId, int peopleId);
        public dynamic GetVotesOfCandidate(int candidateId);
    }
}
