
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : VotingSystemBaseController<User>
    {
        private IUserService userService;
        public UserController(IUserService paramUserService) : base(paramUserService)
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