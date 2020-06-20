
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.Contract.Services
{
    public interface IPeopleService : IBaseService<People>
    {
        public IQueryable<Voter> GetAllVoters();
        public bool RegisterVoter(ref PersonDTO newVoter);
        public bool ChangeAge(int peopleId, int age);
    }
}
