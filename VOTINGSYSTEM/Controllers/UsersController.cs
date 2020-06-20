
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    /// <summary>
    /// It deals with User activities
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : VotingSystemBaseController<User>
    {
        private IUserService userService;
        public UsersController(IUserService paramUserService) : base(paramUserService)
        {
            userService = paramUserService;
        }


        /// <summary>
        /// It will remove user(soft delete)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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