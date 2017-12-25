
using System.Threading.Tasks;

namespace Vig.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VigaDbContext context;
        public UnitOfWork(VigaDbContext context)
        {
            this.context = context;
            
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}