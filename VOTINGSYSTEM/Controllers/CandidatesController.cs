using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : VotingSystemBaseController<Candidate>
    {
        private ICandidateService CandidateService;
        public CandidatesController( ICandidateService candidateService) : base(candidateService)
        {
            CandidateService = candidateService;
        }

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

        [HttpPost]
        [Route("AddCandidateToCategory")] //api/Voters/GetVoterById? id = 2
        public ActionResult AddCandidateToCategory(int categoryId, int peopleId)
        {
            if (!this.CandidateService.TryAddCandidateToCategory(categoryId, peopleId))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(StatusCodes.Status200OK); 
        }

        [HttpGet]
        [Route("GetVotesOfCandidate")] //api/Voters/GetVoterById? id = 2
        public int GetVotesOfCandidate(int candidateId)
        {
            //this.CandidateService.AddCandidateToCategory(categoryId, peopleId);
            //var result = this.BaseService.SaveChanges();
            //return result;
            return 1;
        }
    }
}