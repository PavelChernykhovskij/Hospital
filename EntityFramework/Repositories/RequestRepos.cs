using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.EntityFramework.Repositories
{
    public class RequestRepos : IRepos<Request>
    {
        private readonly IContextFactory _factory;
        public RequestRepos(IContextFactory factory)
        {
            _factory = factory;
            using var context = _factory.CreateContext();
        }

        public bool Create(Request data)
        {
            using var context = _factory.CreateContext();
            context.Requests.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = _factory.CreateContext();
            Request data = context.Requests.Find(id);
            context.Requests.Remove(data);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Request> Read()
        {
            using var context = _factory.CreateContext();
            var data = context.Requests.ToList();
            return data;
        }

        public bool Update(Request data)
        {
            using var context = _factory.CreateContext();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
