using System;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;


namespace VotingSystem.Service
{
    public class CandidateService : BaseService<Candidates>, ICandidateService 
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
            this.Add(new Candidates { CategoryId = categoryId, PeopleId = peopleId, CreatedBy="Admin" });
            this.SaveChanges();
            return true;
        }

        public int RegisterCandidate(CandidateDTO newCandidate)
        {
            int result = 0;
            //1.Candidate 2.Voter
            if (newCandidate.Person != null && newCandidate.Person.User != null)
            {
                Users user = new Users();
                user.UserName = newCandidate.Person.User.UserName;
                user.Password = newCandidate.Person.User.Password;
                user.CreatedBy = "Admin";
                UserService.Add(user);
                UserService.SaveChanges();

                People person = new People();
                person.Address = newCandidate.Person.Address;
                person.Age = newCandidate.Person.Age;
                person.CreatedBy = "Admin";
                person.FirstName = newCandidate.Person.FirstName;
                person.LastName = newCandidate.Person.LastName;
                person.UserId = user.UserId;
                person.UserType = 1;

                PeopleService.Add(person);
                //PeopleService.SaveChanges();

                Candidates candidate = new Candidates();
                candidate.CategoryId = newCandidate.CategoryId;
                candidate.CreatedBy = "Admin";
                candidate.PeopleId = person.PeopleId;
                candidate.People = person;

                this.Add(candidate);
                
                result = this.SaveChanges();
            }

            return result;
        }        
    }
}
