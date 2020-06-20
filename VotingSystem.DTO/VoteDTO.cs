using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.DTO
{
    public class VoteDTO
    {
        public int VoterId { get; set; }

        public int CanndidateId { get; set; }

        public int CategoryId { get; set; }
    }
}
