
using VotingSystem.Models;

namespace VotingSystem.Contract.Services
{
    public interface IVoterService : IBaseService<Voter>
    {
        int ChangeAge(int voterId, int age);
        int VoteForCandidate(int voterId, int canndidateId, int categoryId);
    }
    
}
