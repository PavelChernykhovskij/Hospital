using Microsoft.EntityFrameworkCore;
using Hospital.Services;
using Hospital.Models;
using Hospital.EntityFramework.Repositories;
using Hospital.EntityFramework;
using Hospital.AutoMapping;

namespace Hospital
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.AddControllers();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutoMappingProfile>();
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            //context
            services.AddDbContext<Context>(
                options => options.UseSqlServer(connectionString),
                contextLifetime: ServiceLifetime.Scoped,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IRepos<Doctor>, DoctorRepos>();
            services.AddTransient<IRepos<Medcard>, MedcardRepos>();
            services.AddTransient<IRepos<Question>, QuestionRepos>();
            services.AddTransient<IRepos<Questionnaire>, QuestionnaireRepos>();
            services.AddTransient<IRepos<Request>, RequestRepos>();
            services.AddTransient<IRepos<User>, UserRepos>();

            services.AddHostedService<TestService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            app.UseRouting();
            app.UseEndpoints(conf => conf.MapControllers());

        }


    }

}
