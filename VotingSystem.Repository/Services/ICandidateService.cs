using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.DTO;

namespace VotingSystem.Contract.Services
{
    public interface ICandidateService
    {
       
        public int RegisterCandidate(CandidateDTO newCandidate);
    }
}
