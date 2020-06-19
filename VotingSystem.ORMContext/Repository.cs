using VotingSystem.Contract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace VotingSystem.Repository
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext DatabaseContext;

        public Repository(DbContext context)
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
