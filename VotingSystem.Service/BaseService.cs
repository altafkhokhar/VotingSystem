using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.Service
{
    public abstract class BaseService<TModel> : IBaseService<TModel> where TModel : class
    {

        protected readonly VotingDBContext DatabaseContext;

        public BaseService(VotingDBContext context)
        {
            this.DatabaseContext = context;
        }

        public void Add(TModel entity)
        {
            DatabaseContext.Set<TModel>().Add(entity);
        }

        public ValueTask<TModel> Get(int id)
        {
            return DatabaseContext.Set<TModel>().FindAsync(id);
        }

        public Task<List<TModel>> GetAll()
        {
            return DatabaseContext.Set<TModel>().ToListAsync();
        }

        public void Remove(TModel entity)
        {
            DatabaseContext.Set<TModel>().Remove(entity);
        }

        public int SaveChanges()
        {
            return DatabaseContext.SaveChanges();
        }
    }
}
