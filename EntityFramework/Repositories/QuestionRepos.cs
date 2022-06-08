using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.EntityFramework.Repositories
{
    public class QuestionRepos : IRepos<Question>
    {
        private readonly IContextFactory _factory;
        public QuestionRepos(IContextFactory factory)
        {
            _factory = factory;
            using var context = _factory.CreateContext();
        }
        public bool Create(Question data)
        {
            using var context = _factory.CreateContext();
            context.Questions.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = _factory.CreateContext();
            Question data = context.Questions.Find(id);
            context.Questions.Remove(data);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Question> Read()
        {
            using var context = _factory.CreateContext();
            var data = context.Questions.ToList();
            return data;
        }

        public bool Update(Question data)
        {
            using var context = _factory.CreateContext();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
