using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : VotingSystemBaseController<Category>
    {
        public CategoriesController(ICategoryService categoryService) : base(categoryService)
        {
        }

        //[HttpPost]
        //[Route("PostCategory")] 
        //public int PostCategory(Category category)
        //{   
        //    this.BaseService.Add(category);
        //    var result = this.BaseService.SaveChanges();
        //    return result;
        //}

        

    }
}