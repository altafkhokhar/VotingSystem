using System.Linq;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;
using static VotingSystem.Contract.Helpers.VSHelper;

namespace VotingSystem.Service
{
    public class PeopleService : BaseService<People>, IPeopleService
    {
        private readonly IUserService UserService;
        public PeopleService(IUserService paramUserService, VotingDBContext context) : base(context)
        {
            UserService = paramUserService;
        }

        public IQueryable<People> GetAllVoters()
        {
            return this.DatabaseContext.People.Where(x => x.UserType == (int)UserType.Voter);
        }

        public int RegisterVoter(PersonDTO newVoter)
        {

            int result = 0;
            //1.Candidate 2.Voter
            if (newVoter != null && newVoter.User != null)
            {
                Users user = new Users();
                user.UserName = newVoter.User.UserName;
                user.Password = newVoter.User.Password;
                user.CreatedBy = "Admin";
                UserService.Add(user);
                UserService.SaveChanges();

                People person = new People();
                person.Address = newVoter.Address;
                person.Age = newVoter.Age;
                person.CreatedBy = "Admin";
                person.FirstName = newVoter.FirstName;
                person.LastName = newVoter.LastName;
                person.UserId = user.UserId;
                person.UserType = (int)UserType.Voter;

                this.Add(person);

                result = this.SaveChanges();
            }

            return result;
        }

        public int VoteForCandidate(int peopleId, int candidateId, int categoryId)
        {
            this.DatabaseContext.Votes.Add(new Votes() { CandidateId = candidateId, CategoryId = categoryId, PeopleId = peopleId });
            this.DatabaseContext.SaveChanges();

            return 1;
        }

        public bool ChangeAge(int peopleId, int age)
        {
            this.DatabaseContext.People.Where(wh => wh.PeopleId == peopleId).FirstOrDefault().Age = age;
            this.DatabaseContext.SaveChanges();

            return true;
        }
    }
}
