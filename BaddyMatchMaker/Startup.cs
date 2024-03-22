using BaddyMatchMaker.Models;
using BaddyMatchMaker.Repository;
using BaddyMatchMaker.Services;
using BaddyMatchMaker.Strategies.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BaddyMatchMaker
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
            services.AddControllers();

            var connection = @"Server=localhost\SQLEXPRESS;Database=BaddyMatchMaker;uid=admin;password=admin;ConnectRetryCount=0";
            services.AddDbContext<BaddyMatchMakerContext>(options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISessionManagementService, SessionManagementService>();
            services.AddScoped<IMatchMakingService, MatchMakingService>();
            services.AddScoped<IMatchGroupingStrategyFactory, MatchGroupingStrategyFactory>();
            services.AddScoped<IPlayerPoolSelectionStrategyFactory, PlayerPoolSelectionStrategyFactory>();
            services.AddScoped<IShuffleService, FisherYatesShuffle>();
            services.AddScoped<IPlayerPrioritizationService, DefaultPrioritizationService>();
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
        }
    }
}
