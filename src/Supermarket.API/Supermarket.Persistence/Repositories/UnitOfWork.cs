using Supermarket.Core.Repositories;
using Supermarket.Persistence.Contexts;

namespace Supermarket.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SupermarketContext _context;

        public UnitOfWork(SupermarketContext context) 
        { 
            _context = context;
        }

        public async Task CompleteAsync() 
        { 
            await _context.SaveChangesAsync();
        }
    }
}
