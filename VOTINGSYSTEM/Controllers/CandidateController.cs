
using Microsoft.AspNetCore.Mvc;
using VotingSystem.API.ViewModel;
using VotingSystem.Contract;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : VotingSystemBaseController<Candidates, ICandidateRepository>
    {
        private ICandidateService CandidateService;
        public CandidateController(ICandidateRepository candidateRepository, ICandidateService candidateService) : base(candidateRepository)
        {
            CandidateService = candidateService;
        }

        [HttpPost]
        [Route("PostCandidate")] //api/PostCandidate
        public int PostCandidate(CandidateDTO candidate)
        {
            return CandidateService.RegisterCandidate(candidate);
        }       

    }
}