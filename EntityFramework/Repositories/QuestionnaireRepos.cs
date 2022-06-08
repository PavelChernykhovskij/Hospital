using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.EntityFramework.Repositories
{
    public class QuestionnaireRepos : IRepos<Questionnaire>
    {
        private readonly IContextFactory _factory;
        public QuestionnaireRepos(IContextFactory factory)
        {
            _factory = factory;
            using var context = _factory.CreateContext();
        }
        public bool Create(Questionnaire data)
        {
            using var context = _factory.CreateContext();
            context.Questionnairies.Add(data);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            using var context = _factory.CreateContext();
            Questionnaire data = context.Questionnairies.Find(id);
            context.Questionnairies.Remove(data);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Questionnaire> Read()
        {
            using var context = _factory.CreateContext();
            var data = context.Questionnairies
                    .Include(q => q.Questions)
                    .ToList();
            return data;
        }

        public bool Update(Questionnaire data)
        {
            using var context = _factory.CreateContext();
            context.Entry(data).State = EntityState.Modified;
            return true;
        }
    }
}
