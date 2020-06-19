using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Models;
using VotingSystem.Contract;


namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    //[Route("[controller]")]
    [ApiController]
    public class VotersController : VotingSystemBaseController<Voters, IVoterRepository>
    {
        public VotersController(IVoterRepository voterRepository) : base(voterRepository)
        {
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Voters> ByCurrentYear()
        {
            return null;// base.Repository.GetBooksByCurrentYear();
        }

        [HttpGet]
        [Route("GetVoterById")] //api/Voters/GetVoterById? id = 2
        public async Task<Voters> GetVoterById(int id)
        {
            return await base.Repository.Get(id);
            
        }

        
        //[HttpGet]
        /////api/Voters
        //public async Task<IEnumerable<Voter>> GetVoters()
        //{
        //    return await base.Repository.GetAll();
        //}
    }
}