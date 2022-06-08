using Hospital.Models;

namespace Hospital.EntityFramework.Repositories
{
    public interface IRepos<T>
    {
        bool Create(T data);
        IEnumerable<T> Read();
        bool Update(T data);
        bool Delete(int id);
    }
}
