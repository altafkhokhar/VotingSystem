using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.Contract.Helpers
{
    public class VSHelper
    {
        public const int MIN_AGE_FOR_VOTING = 18;
        public enum UserType
        {
            Candidate=1,
            Voter=2
        }
    }
}
