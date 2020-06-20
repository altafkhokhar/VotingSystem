using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotersController :  VotingSystemBaseController<People>
    {
        private IPeopleService peopleService;
        private IVoterService voterService;
        public VotersController(IPeopleService paramService, IVoterService paeramVoterService) : base(paramService)
        {
            peopleService = paramService;
            voterService = paeramVoterService;
        }        

        [HttpPost]
        [Route("RegisterVoter")] 
        public  int RegisterVoter(PersonDTO newVoter)
        {
            return  peopleService.RegisterVoter(newVoter);
            
        }


        [HttpGet]
        [Route("GetVoters")]
        ///api/Voters
        public IEnumerable<Voter> GetVoters()
        {
            return  peopleService.GetAllVoters();
        }

        [HttpPost]
        [Route("ChangeAge")]
        public int ChangeAge(int peopleId, int age)
        {
            //return peopleService.ChangeAge(peopleId, age);
            return 1;
        }

        [HttpGet("{id}")] //api/Voters/1
        public override People GetItem([FromRoute] int id)
        {
            return this.voterService.Get(id).Result.People;

        }
    }
}