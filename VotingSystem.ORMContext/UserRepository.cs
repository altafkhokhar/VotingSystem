
using VotingSystem.Contract;
using VotingSystem.Models;

namespace VotingSystem.Repository
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public VotingDBContext ApplicationDatabaseContext
        {
            get { return DatabaseContext as VotingDBContext; }
        }
        public UserRepository(VotingDBContext context) : base(context) { }
    }
}
