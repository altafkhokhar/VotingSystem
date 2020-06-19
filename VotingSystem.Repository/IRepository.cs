using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Contract
{
    public interface IRepository<TModel> where TModel : class
    {
        ValueTask<TModel> Get(int id);
        Task<List<TModel>> GetAll();
        void Add(TModel entity);
        void Remove(TModel entity);
    }
}
