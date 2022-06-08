using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.EntityFramework.Config;

namespace Hospital.EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Medcard> Medcards => Set<Medcard>();
        public DbSet<Questionnaire> Questionnairies => Set<Questionnaire>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Request> Requests => Set<Request>();


        public Context(DbContextOptions<Context> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new MedcardConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionnaireConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
