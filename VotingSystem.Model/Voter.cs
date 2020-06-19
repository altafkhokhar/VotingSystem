using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Model
{
    public class Voter
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 5)]
        public string Name { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime Date
        //{
        //    get; set;
        //}
    }
}
