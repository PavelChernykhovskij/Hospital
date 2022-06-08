using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.EntityFramework.Repositories
{
    public class MedcardRepos : IRepos<Medcard>
    {
        private readonly IContextFactory _factory;
        public MedcardRepos(IContextFactory factory)
        {
            _factory = factory;
            using var context = _factory.CreateContext();
        }
        public bool Create(Medcard data)
        {
            using var context = _factory.CreateContext();
            context.Medcards.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = _factory.CreateContext();
            Medcard data = context.Medcards.Find(id);
            context.Medcards.Remove(data);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Medcard> Read()
        {
            using var context = _factory.CreateContext();
            var data = context.Medcards
                    .Include(u => u.Requests)
                    .ToList();
            return data;
        }

        public bool Update(Medcard data)
        {
            using var context = _factory.CreateContext();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
