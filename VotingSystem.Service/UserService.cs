using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Contract;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.Service
{
   public class UserService : BaseService<Users>, IUserService
    {
        
        public UserService(VotingDBContext context) : base(context)
        {
           
        }
    }
}
