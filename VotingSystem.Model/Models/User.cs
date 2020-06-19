using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class User
    {
        public User()
        {
            People = new HashSet<People>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<People> People { get; set; }
    }
}
