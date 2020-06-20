using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VotingSystem.Contract;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(VotingDBContext context) : base(context)
        {

        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var userDetail = this.DatabaseContext.User.Where(wh => wh.UserId == userId).FirstOrDefault();
                var result = ValidateForDeleteUser(userDetail);

                userDetail.IsDeleted = true;
                this.DatabaseContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool ValidateForDeleteUser(User userDetail)
        {
            if (userDetail == null)
                //user doesnot exist
                return false;
            return true;
        }

    }
}