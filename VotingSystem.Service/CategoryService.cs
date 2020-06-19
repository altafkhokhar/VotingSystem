using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.Service
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(VotingDBContext context) :base(context)
        {
            
        }

    }
}
