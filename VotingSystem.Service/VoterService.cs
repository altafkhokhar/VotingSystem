﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VotingSystem.Contract.Services;
using VotingSystem.Models;

namespace VotingSystem.Service
{
    public class VoterService : BaseService<Voter>, IVoterService
    {
        public VoterService(VotingDBContext context) : base(context)
        {

        }

        public int ChangeAge(int voterId, int paramAge)
        {
            try
            {
                var voter = this.DatabaseContext.Voter.Where(x => x.VoterId == voterId).FirstOrDefault();
                if (voter != null)
                {
                    var people = this.DatabaseContext.People.Where(p => p.PeopleId == voter.PeopleId).FirstOrDefault();
                    if (people != null)
                    {
                        var alreadyVoted = this.DatabaseContext.Vote.FirstOrDefault(wh => wh.VoterId == voterId);
                        if (alreadyVoted != null)
                        {
                            if (paramAge < 18)
                            {
                                return -2; // can not update age below 18 since he/she already voted.
                            }
                            else
                            {
                                people.Age = paramAge;
                                this.DatabaseContext.SaveChanges();

                                return 1; // age updated;
                            }
                        }
                        else
                        {
                            people.Age = paramAge;
                            this.DatabaseContext.SaveChanges();

                            return 1; // age updated;
                        }



                    }
                }
            }
            catch
            {
                return -1; // error
            }
            return 1;
        }

        public int VoteForCandidate(int voterId, int canndidateId, int categoryId)
        {
            try
            {
                var voter = this.DatabaseContext.Voter.Where(x => x.VoterId == voterId).FirstOrDefault();
                var candidate = this.DatabaseContext.Candidate.Where(wh => wh.CandidateId == canndidateId).FirstOrDefault();
                var category = this.DatabaseContext.Category.Where(x => x.CategoryId == categoryId).FirstOrDefault();

                if (voter == null || candidate == null || category == null)
                {
                    return -2;
                }

                var voteForCandidateByCategory = this.DatabaseContext.Vote.Where(y => y.VoterId == voterId && y.CandidateId == canndidateId && y.CategoryId == categoryId).FirstOrDefault();
                if (voteForCandidateByCategory != null)
                    return -3; // already voted for candidate and category

                this.DatabaseContext.Vote.Add(new Vote { VoterId = voterId, CategoryId = categoryId, CandidateId = canndidateId, CreatedBy = "Admin" });
                this.DatabaseContext.SaveChanges();

            }
            catch
            {
                return -1; // error
            }

            return 1;
        }
    }
}
