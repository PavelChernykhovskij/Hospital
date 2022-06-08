using Hospital.Models;
using Hospital.EntityFramework.Repositories;

namespace Hospital.Services
{
    public class TestService : IHostedService
    {
        private readonly IRepos<Doctor> _repos;
        public TestService(IRepos<Doctor> repos)
        {
            _repos = repos;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
          
            foreach (var repo in _repos.Read())
            {
                Console.WriteLine($"Имя врача:{repo.Name} заявки: {repo.Requests.FirstOrDefault().Comment}");
            }
            Console.WriteLine();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Hosted Service is stopping.");

            return Task.CompletedTask;
        }
    }
}
