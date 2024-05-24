using Supermarket.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly SupermarketContext _context;

        public BaseRepository(SupermarketContext context) 
        { 
            _context = context;
        }
    }
}
