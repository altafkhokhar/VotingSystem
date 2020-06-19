using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;

using VotingSystem.Contract;
using VotingSystem.Repository;
using VotingSystem.Models;
using VotingSystem.Service;
using VotingSystem.Contract.Services;

namespace VOTINGSYSTEM
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDependecies(services);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseMvc();
        }

        /// <summary>
        /// Register depedencies in this method
        /// </summary>
        /// <param name="services"></param>
        private void  RegisterDependecies(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("VOTINGSYSTEM_DB_STRING");
            services.AddDbContext<VotingDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IVoterRepository, VoterRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();

            services.AddScoped<ICandidateService, CandidateService>();


        }
    }
}
