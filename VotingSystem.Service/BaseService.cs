using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.Service
{
    /// <summary>
    /// Its base service class and do many common operations in generic way.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
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

        /// <summary>
        /// It will add record in respective table and also perform savechanges.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool TryAdd(ref TModel entity)
        {
            DatabaseContext.Set<TModel>().Add(entity);
            DatabaseContext.SaveChanges();

            return true;
        }

    public ValueTask<TModel> Get(int id)
        {
            return DatabaseContext.Set<TModel>().FindAsync(id);
        }

        public bool TryGet(int id, out TModel item)
        {
            item =  DatabaseContext.Set<TModel>().FindAsync(id).Result;
            if (item == null)
            {
                return false;
            }

            return true;
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
