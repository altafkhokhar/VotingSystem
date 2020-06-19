using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController :  VotingSystemBaseController<People>
    {
        private IPeopleService peopleService;
        public VoterController(IPeopleService paramService) : base(paramService)
        {
            peopleService = paramService;
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
        public IEnumerable<People> GetVoters()
        {
            return  peopleService.GetAllVoters();
        }
    }
}