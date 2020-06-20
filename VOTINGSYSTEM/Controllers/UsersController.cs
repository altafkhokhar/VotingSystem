
using Microsoft.AspNetCore.Http;
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

        [HttpDelete("{id}")]
        [Route("DeleteUser")]
        public ActionResult DeleteUser([FromRoute]int id)
        {
            if (!userService.DeleteUser(id))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status410Gone);

        }
    }
  
}