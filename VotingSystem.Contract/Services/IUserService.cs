
using VotingSystem.Models;

namespace VotingSystem.Contract.Services
{
    public interface IUserService : IBaseService<User>
    {
        public bool DeleteUser(int userId);
    }
}
