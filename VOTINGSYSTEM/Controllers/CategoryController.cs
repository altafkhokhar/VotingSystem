using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : VotingSystemBaseController<Category, ICategoryRepository>
    {
        public CategoryController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpPost]
        [Route("PostCategory")] //api/Voters/GetVoterById? id = 2
        public string PostCategory(Category category)
        {
            return  "test";

        }

        //[Route("[SaveCategoryPostCategory
        //[HttpGet]
        //public string SaveCategory(string categoryName)
        //{
        //    return "categoryName";// base.Repository.GetBooksByCurrentYear();
        //}
    }
}