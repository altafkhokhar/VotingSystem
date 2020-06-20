

namespace VotingSystem.Contract.Helpers
{
    public class VSHelper
    {
        public const int MIN_AGE_FOR_VOTING = 18;
        public const string VOTINSYSTEM_DB_STRING = "VOTINGSYSTEM_DB_STRING";

        public const string PROC_CANDIDATE_VOTE_COUNT = "USP_CandidateVoteCount";
            
        public enum UserType
        {
            Candidate=1,
            Voter=2
        }
    }
}
