using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Contract;
using VotingSystem.Contract.Services;
using VotingSystem.Service;

namespace VotingSystem.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public abstract class VotingSystemBaseController<TModel, TRepository> : ControllerBase where TModel : class where TRepository : IRepository<TModel>
    //{
    //    protected readonly TRepository Repository;

    //    public VotingSystemBaseController(TRepository repository)
    //    {
    //        this.Repository = repository;
    //    }

    //    [HttpGet]
    //    public async Task<IEnumerable<TModel>> Get()
    //    {
    //        return await Repository.GetAll();
    //    }

    //    [HttpPost]
    //    public void Add([FromBody] TModel item)
    //    {
    //        Repository.Add(item);
    //        Repository.SaveChanges();
    //    }
    //}

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
        public void Add([FromBody] TModel item)
        {
            this.BaseService.Add(item);
            this.BaseService.SaveChanges();
        }
    }
}