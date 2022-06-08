using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.EntityFramework.Repositories
{
    public class UserRepos : IRepos<User>
    {
        private readonly IContextFactory _factory;
        public UserRepos(IContextFactory factory)
        {
            _factory = factory;
            using var context = _factory.CreateContext();
        }
        public bool Create(User data)
        {
            using var context = _factory.CreateContext();
            context.Users.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = _factory.CreateContext();
            User data = context.Users.Find(id);
            context.Users.Remove(data);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<User> Read()
        {
            using var context = _factory.CreateContext();
            var data = context.Users.ToList();
            return data;
        }

        public bool Update(User data)
        {
            using var context = _factory.CreateContext();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
