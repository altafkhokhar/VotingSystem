using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VotingSystem.Models
{
    public partial class Category

    {
        public bool IsValid(VotingDBContext dbContext)
        {
            var existingCategory = dbContext.Category.Where(wh => wh.CategoryName == CategoryName.Trim()).FirstOrDefault();
            //&& (!wh.IsDeleted.HasValue || wh.IsDeleted.Value == false)) enhancement since no provision for delete operation.
            if (existingCategory != null)
                return false;

            return true;
        }
    }
}
