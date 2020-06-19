
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : VotingSystemBaseController<Users>
    {
        public UserController(IUserService userService) : base(userService)
        {
        }    
    }
}