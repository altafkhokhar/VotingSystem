using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.DTO
{
    public class CandidateResult
    {
        public int CandidateId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int TotalVotes { get; set; }
    }
}
