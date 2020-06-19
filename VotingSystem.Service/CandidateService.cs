using System;
using VotingSystem.Contract;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;
using VotingSystem.Repository;

namespace VotingSystem.Service
{
    public class CandidateService : BaseService, ICandidateService 
    {
        private readonly ICandidateRepository CandidateRepository;
        private readonly IUserRepository UserRepository;
        private readonly IPeopleRepository PeopleRepository;
        public CandidateService(ICandidateRepository repository, IUserRepository userRepository, IPeopleRepository peopleRepository)
        {
            CandidateRepository = repository;
            UserRepository = userRepository;
            PeopleRepository = peopleRepository;
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
                UserRepository.Add(user);
                UserRepository.SaveChanges();

                People person = new People();
                person.Address = newCandidate.Person.Address;
                person.Age = newCandidate.Person.Age;
                person.CreatedBy = "Admin";
                person.FirstName = newCandidate.Person.FirstName;
                person.LastName = newCandidate.Person.LastName;
                person.UserId = user.UserId;
                person.UserType = 1;

                PeopleRepository.Add(person);
                UserRepository.SaveChanges();

                Candidates candidate = new Candidates();
                candidate.CategoryId = newCandidate.CategoryId;
                candidate.CreatedBy = "Admin";
                candidate.PeopleId = person.PeopleId;

                
                
                CandidateRepository.Add(candidate);
                
                result = CandidateRepository.SaveChanges();
            }

            return result;
        }
    }
}
