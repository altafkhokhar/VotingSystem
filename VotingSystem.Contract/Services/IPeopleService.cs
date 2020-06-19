
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.Contract.Services
{
    public interface IPeopleService : IBaseService<People>
    {
        public IQueryable<People> GetAllVoters();
        public int RegisterVoter(PersonDTO newVoter);
    }
}
