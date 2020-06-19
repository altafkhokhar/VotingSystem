using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Contract;

namespace VotingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class VotingSystemBaseController<TModel, TRepository> : ControllerBase where TModel : class where TRepository : IRepository<TModel>
    {
        protected readonly TRepository Repository;

        public VotingSystemBaseController(TRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TModel>> Get()
        {
            return await Repository.GetAll();
        }

        [HttpPost]
        public void Add([FromBody] TModel item)
        {
            Repository.Add(item);
        }
    }
}