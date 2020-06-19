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
        public int PostCategory(Category category)
        {
            Repository.Add(category);
            int result = Repository.SaveChanges();
            return result;
        }

        //[Route("[SaveCategoryPostCategory
        //[HttpGet]
        //public string SaveCategory(string categoryName)
        //{
        //    return "categoryName";// base.Repository.GetBooksByCurrentYear();
        //}
    }
}