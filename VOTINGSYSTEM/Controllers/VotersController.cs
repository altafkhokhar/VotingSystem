using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    /// <summary>
    /// It deals with Voter stuff
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VotersController :  VotingSystemBaseController<Voter>
    {
        private IPeopleService peopleService;
        private IVoterService voterService;
        public VotersController(IPeopleService paramService, IVoterService paeramVoterService) : base(paeramVoterService)
        {
            peopleService = paramService;
            voterService = paeramVoterService;
        }        

        /// <summary>
        /// It will register new voter
        /// </summary>
        /// <param name="newVoter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegisterVoter")] 
        public  ActionResult RegisterVoter(PersonDTO newVoter)
        {
            var result = peopleService.RegisterVoter(ref newVoter);
            if (result == -1) // error
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else if (result == -2)
                return StatusCode(StatusCodes.Status400BadRequest, "Can not register person as voter her/his age is below 18!");// can not update due to below 18
            

            newVoter.User = null;//to hide user detail;
            return Created(nameof(GetItem), newVoter);
        }

        /// <summary>
        /// It will return all voters.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVoters")]
        ///api/Voters
        public IEnumerable<Voter> GetVoters()
        {
            return  peopleService.GetAllVoters();
        }


        /// <summary>
        /// It will update age of voter
        /// </summary>
        /// <param name="voterdto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangeAge")]
        public ActionResult ChangeAge([FromBody]VoterDTO voterdto)
        {
            try
            {
                var result = voterService.ChangeAge(voterdto.VoterId, voterdto.Age);
                if (result == 1)
                    return StatusCode(StatusCodes.Status200OK);
                else if(result == -2)
                    return StatusCode(StatusCodes.Status400BadRequest,"Can not update Age!");// can not update due to below 18
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status200OK);
        }


        /// <summary>
        /// It will return voter using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] //api/Voters/1
        public override ActionResult<Voter> GetItem([FromRoute] int id)
        {

            Voter item = null;
            if (!this.voterService.TryGet(id, out item))
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// It will submit vote for candidate to particular category from voter
        /// </summary>
        /// <param name="voteDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("VoteForCandidate")]
        public ActionResult VoteForCandidate([FromBody]VoteDTO voteDto)
        {
            try
            {
                var result = voterService.VoteForCandidate(voteDto.VoterId, voteDto.CanndidateId, voteDto.CategoryId );
                if (result == -1)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                else if (result == -2)
                    return StatusCode(StatusCodes.Status400BadRequest, "Resource not found");// can not update due to below 18
                else if(result == -3)
                    return StatusCode(StatusCodes.Status400BadRequest, "Can not Vote!");// can not vote already voted for category and candidate 
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}