using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using VotingSystem.Contract.Services;

namespace VotingSystem.API.Controllers
{
   
    /// <summary>
    /// Base class for all API controller
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class VotingSystemBaseController<TModel> : ControllerBase where TModel : class
    {
        protected readonly IBaseService<TModel> BaseService;

        public VotingSystemBaseController(IBaseService<TModel> paramService)
        {
            BaseService = paramService;
        }


        /// <summary>
        /// It will return all records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TModel>> Get()
        {  
                return await this.BaseService.GetAll();
         }

        /// <summary>
        /// It will create new record
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
            return Created(nameof(GetItem), item );
            
        }
        /// <summary>
        /// It will return one record using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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