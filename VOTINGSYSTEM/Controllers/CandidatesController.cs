using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{

    /// <summary>
    /// It will deal with Candidate
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : VotingSystemBaseController<Candidate>
    {
        private ICandidateService CandidateService;
        public CandidatesController( ICandidateService candidateService) : base(candidateService)
        {
            CandidateService = candidateService;
        }

        /// <summary>
        /// It will register new candidate
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostCandidate")] //api/PostCandidate
        public ActionResult PostCandidate(CandidateDTO candidate)
        {
            
            if (!CandidateService.TryRegisterCandidate(ref candidate))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        
            return Created(nameof(GetItem), candidate);
        }

        /// <summary>
        /// It will associate candidate with category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="peopleId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCandidateToCategory")] //api/Voters/GetVoterById? id = 2
        public ActionResult AddCandidateToCategory(int categoryId, int peopleId)
        {
            var result = this.CandidateService.TryAddCandidateToCategory(categoryId, peopleId);
            if (result == -1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else if (result == -2)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return StatusCode(StatusCodes.Status200OK); 
        }


        /// <summary>
        /// It willl return Vote count of particular candiate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("VotesOfCandidate")] //api/Candidates/VotesOfCandidate? id = 2
        public ActionResult<IList<CandidateResult>> VotesOfCandidate([FromRoute] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, this.CandidateService.GetVotesOfCandidate(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }
    }
}