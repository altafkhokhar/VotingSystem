using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using VotingSystem.Contract.Services;
using VotingSystem.DTO;
using VotingSystem.Models;


namespace VotingSystem.Service
{
    /// <summary>
    /// This service perform operation related to Candidate
    /// </summary>
    public class CandidateService : BaseService<Candidate>, ICandidateService 
    {
        private readonly IUserService UserService;
        private readonly IPeopleService PeopleService;
        private IConfiguration Configuration;

        public CandidateService(IUserService userService, IPeopleService peopleService, IConfiguration configuration, VotingDBContext context)  : base(context)
        {
           
            UserService = userService;
            PeopleService = peopleService;
            Configuration = configuration;
        }


        /// <summary>
        /// It will add candidate to category after validation
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="peopleId"></param>
        /// <returns></returns>
        public int TryAddCandidateToCategory(int categoryId, int peopleId)
        {
            try
            {
                var category = this.DatabaseContext.Category.Where(wh => wh.CategoryId == categoryId).FirstOrDefault();
                var people = this.DatabaseContext.People.Where(x => x.PeopleId == peopleId).FirstOrDefault();
                if (category == null || people == null)
                {
                    return -2; // bad request category or people is not exist.
                }
                this.Add(new Candidate { CategoryId = categoryId, PeopleId = peopleId, CreatedBy = "Admin" });
                this.SaveChanges();
            }
            catch
            {
                return -1; // error
            }
            return 1; // done.
        }


        /// <summary>
        /// It registers new candidate
        /// </summary>
        /// <param name="newCandidate"></param>
        /// <returns></returns>
        public bool TryRegisterCandidate(ref CandidateDTO newCandidate)
        {
            try
            {

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

                    this.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// It will return vote counts of candidate
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        public IList<CandidateResult> GetVotesOfCandidate(int candidateId)
        {
            try
            {   
                var candidateResults = new List<CandidateResult>();

                string conString = Configuration.GetConnectionString(VotingSystem.Contract.Helpers.VSHelper.VOTINSYSTEM_DB_STRING);
                var con = new SqlConnection(conString);
                con.Open();
                                
                string CommandText = VotingSystem.Contract.Helpers.VSHelper.PROC_CANDIDATE_VOTE_COUNT + " @CandidateId" ;
                var cmd = new SqlCommand(CommandText);
                cmd.Connection = con;

                cmd.Parameters.Add(
                    new SqlParameter("@CandidateId", System.Data.SqlDbType.Int));

                cmd.Parameters["@CandidateId"].Value = candidateId;
                                
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {         
                    int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    string CategoryName = Convert.ToString(reader["CategoryName"]);
                    int VoteCount = Convert.ToInt32(reader["VoteCount"]);

                    candidateResults.Add(new CandidateResult {CandidateId = candidateId, CategoryId = CategoryId, CategoryName = CategoryName, TotalVotes = VoteCount });
                    
                }
                
                return candidateResults;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
