using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using VotingSystem.Contract.Services;

namespace VotingSystem.API.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public abstract class VotingSystemBaseController<TModel> : ControllerBase where TModel : class
    {
        protected readonly IBaseService<TModel> BaseService;

        public VotingSystemBaseController(IBaseService<TModel> paramService)
        {
            BaseService = paramService;
        }

        [HttpGet]
        public async Task<IEnumerable<TModel>> Get()
        {  
                return await this.BaseService.GetAll();
         }

        [HttpPost]
        public ActionResult<TModel> Add([FromBody] TModel item)
        {
            try
            {
                this.BaseService.TryAdd(ref item);
            }
            catch //Logger out of scope
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //var createdResult = new CreatedResult();
            return Created(nameof(GetItem), item );
            //return ("Resource created successfully!");
        }


        [HttpGet("{id}")] //api/Categories/2
        public virtual ActionResult<TModel> GetItem([FromRoute] int id)
        {
            TModel item = null;
            try
            {
                if (!this.BaseService.TryGet(id, out item))
                {
                    return NotFound();
                }

            }
            catch //Logger out of scope
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return item;
         
        }

    }
}