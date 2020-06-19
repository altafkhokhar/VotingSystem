using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.Service
{
    public class VoterService : BaseService<Voter>, IVoterService
    {
        public VoterService(VotingDBContext context) : base(context)
        {

        }
    }
}
