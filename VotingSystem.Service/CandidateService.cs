using System;
using System.Linq;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;


namespace VotingSystem.Service
{
    public class CandidateService : BaseService<Candidate>, ICandidateService 
    {
        private readonly IUserService UserService;
        private readonly IPeopleService PeopleService;
        public CandidateService(IUserService userService, IPeopleService peopleService, VotingDBContext context)  : base(context)
        {
           
            UserService = userService;
            PeopleService = peopleService;
        }

        public bool AddCandidateToCategory(int categoryId, int peopleId)
        {
            this.Add(new Candidate { CategoryId = categoryId, PeopleId = peopleId, CreatedBy="Admin" });
            this.SaveChanges();
            return true;
        }

        public int RegisterCandidate(CandidateDTO newCandidate)
        {
            int result = 0;
            //1.Candidate 2.Voter
            if (newCandidate.Person != null && newCandidate.Person.User != null)
            {
                User user = new User();
                user.UserName = newCandidate.Person.User.UserName;
                user.Password = newCandidate.Person.User.Password;
                user.CreatedBy = "Admin";
                
                UserService.Add(user);
                
                People person = new People();
                person.Address = newCandidate.Person.Address;
                person.Age = newCandidate.Person.Age;
                person.CreatedBy = "Admin";
                person.FirstName = newCandidate.Person.FirstName;
                person.LastName = newCandidate.Person.LastName;
                
                person.User = user;

                PeopleService.Add(person);

                Candidate candidate = new Candidate();
                candidate.CategoryId = newCandidate.CategoryId;
                candidate.CreatedBy = "Admin";
                candidate.People = person;

                this.Add(candidate);
                
                result = this.SaveChanges();
            }

            return result;
        }

        public dynamic GetVotesOfCandidate(int candidateId)
        {
            //this.DatabaseContext.Votes.GroupBy(x=> x.CategoryId).Select()
            return null;
        
        }
    }
}
