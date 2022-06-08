using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.EntityFramework.Repositories
{
    public class DoctorRepos : IRepos<Doctor>
    {
        private readonly IContextFactory _factory;
        public DoctorRepos(IContextFactory factory)
        {
            _factory = factory;
            using var context = _factory.CreateContext();
        }
        public bool Create(Doctor data)
        {
            using var context = _factory.CreateContext();
            context.Doctors.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = _factory.CreateContext();
            Doctor data = context.Doctors.Find(id);
            context.Doctors.Remove(data);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Doctor> Read()
        {
            using var context = _factory.CreateContext();
            var data = context.Doctors
                    .Include(u => u.Requests) 
                    .ToList();
            return data;
        }

        public bool Update(Doctor data)
        {
            using var context = _factory.CreateContext();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
