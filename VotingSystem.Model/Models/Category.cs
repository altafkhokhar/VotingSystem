using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class Category
    {
        public Category()
        {
            Candidates = new HashSet<Candidates>();
            Votes = new HashSet<Votes>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Candidates> Candidates { get; set; }
        public virtual ICollection<Votes> Votes { get; set; }
    }
}
