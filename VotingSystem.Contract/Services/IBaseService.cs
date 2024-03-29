﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Contract.Services
{
    public interface IBaseService<TModel>
    {
        ValueTask<TModel> Get(int id);
        bool TryGet(int id, out TModel item);
        Task<List<TModel>> GetAll();
        void Add(TModel entity);

        bool TryAdd(ref TModel entity);
        void Remove(TModel entity);

      
        int SaveChanges();
    }
}
