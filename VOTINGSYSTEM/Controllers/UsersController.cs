﻿
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : VotingSystemBaseController<User>
    {
        private IUserService userService;
        public UsersController(IUserService paramUserService) : base(paramUserService)
        {
            userService = paramUserService;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public void DeleteUser(int id)
        {
            userService.DeleteUser(id);
        }
    }
  
}