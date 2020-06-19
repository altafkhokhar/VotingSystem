using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class People
    {
        public People()
        {
            Candidate = new HashSet<Candidate>();
            Voter = new HashSet<Voter>();
        }

        public int PeopleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserId { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Candidate> Candidate { get; set; }
        public virtual ICollection<Voter> Voter { get; set; }
    }
}
