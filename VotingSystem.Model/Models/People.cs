using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class People
    {
        public People()
        {
            Candidates = new HashSet<Candidates>();
            Votes = new HashSet<Votes>();
        }

        public int PeopleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserId { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int UserType { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Candidates> Candidates { get; set; }
        public virtual ICollection<Votes> Votes { get; set; }
    }
}
