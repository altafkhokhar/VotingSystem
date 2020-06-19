using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class Vote
    {
        public int VoteId { get; set; }
        public int VoterId { get; set; }
        public int CandidateId { get; set; }
        public int CategoryId { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Category Category { get; set; }
    }
}
