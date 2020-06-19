using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : VotingSystemBaseController<Candidate>
    {
        private ICandidateService CandidateService;
        public CandidateController( ICandidateService candidateService) : base(candidateService)
        {
            CandidateService = candidateService;
        }

        [HttpPost]
        [Route("PostCandidate")] //api/PostCandidate
        public int PostCandidate(CandidateDTO candidate)
        {
            return CandidateService.RegisterCandidate(candidate);
        }

        [HttpPost]
        [Route("AddCandidateToCategory")] //api/Voters/GetVoterById? id = 2
        public int AddCandidateToCategory(int categoryId, int peopleId)
        {
            this.CandidateService.AddCandidateToCategory(categoryId, peopleId);
            var result = this.BaseService.SaveChanges();
            return result;
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