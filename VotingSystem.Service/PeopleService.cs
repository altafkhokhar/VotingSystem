﻿using System;
using System.Collections.Generic;
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
        private readonly IVoterService VoterService;
        public PeopleService(IUserService paramUserService, IVoterService paramVoterService, VotingDBContext context) : base(context)
        {
            UserService = paramUserService;
            VoterService = paramVoterService;
        }

        public IQueryable<Voter> GetAllVoters()
        {
            return this.DatabaseContext.Voter.AsQueryable();
        }

        public bool RegisterVoter(ref PersonDTO newVoter)
        {
            try
            {
                 //1.Candidate 2.Voter
                if (newVoter != null && newVoter.User != null)
                {
                    User user = new User();
                    user.UserName = newVoter.User.UserName;
                    user.Password = newVoter.User.Password;
                    user.CreatedBy = "Admin";
                    UserService.Add(user);

                    People person = new People();
                    person.Address = newVoter.Address;
                    person.Age = newVoter.Age;
                    person.CreatedBy = "Admin";
                    person.FirstName = newVoter.FirstName;
                    person.LastName = newVoter.LastName;
                    person.User = user;

                    this.Add(person);
                    this.SaveChanges();

                    Voter voter = new Voter();
                    voter.People = person;
                    voter.CreatedBy = "Admin";
                    VoterService.Add(voter);

                    this.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public int VoteForCandidate(int voterId, int candidateId, int categoryId)
        {
            this.DatabaseContext.Vote.Add(new Vote() { CandidateId = candidateId, CategoryId = categoryId, VoterId = voterId });
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
