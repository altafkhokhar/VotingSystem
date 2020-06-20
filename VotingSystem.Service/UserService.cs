using System.Linq;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.Service
{
    /// <summary>
    /// This service perform operation related to User
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(VotingDBContext context) : base(context)
        {

        }


        /// <summary>
        /// It removes user from system after validation
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// It validates user for delete operation
        /// </summary>
        /// <param name="userDetail"></param>
        /// <returns></returns>
        private bool ValidateForDeleteUser(User userDetail)
        {
            //validations can be added over here based on requirement, this is just to simplify
            if (userDetail == null)
                //user doesnot exist
                return false;
            return true;
        }

    }
}