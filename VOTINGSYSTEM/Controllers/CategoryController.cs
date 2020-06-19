using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : VotingSystemBaseController<Category>
    {
        public CategoryController(ICategoryService categoryService) : base(categoryService)
        {
        }

        [HttpPost]
        [Route("PostCategory")] //api/Voters/GetVoterById? id = 2
        public int PostCategory(Category category)
        {
            this.BaseService.Add(category);
            var result = this.BaseService.SaveChanges();
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