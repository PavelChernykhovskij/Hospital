using Microsoft.EntityFrameworkCore;
namespace Hospital.EntityFramework
{
    public class ContextFactory : IContextFactory
    {
        private readonly DbContextOptions<Context> _options;
        public ContextFactory(DbContextOptions<Context> options)
        {
            _options = options;
        }

        public Context CreateContext()
        {
            return new Context(_options);
        }
    }
}
