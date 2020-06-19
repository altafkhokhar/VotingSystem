using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Models;
using VotingSystem.Contract;

namespace VotingSystem.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public VotingDBContext ApplicationDatabaseContext
        {
            get { return DatabaseContext as VotingDBContext; }
        }

        public CategoryRepository(VotingDBContext context) : base(context) { }

    }
}
