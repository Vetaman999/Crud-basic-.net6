using prueba.Domain.Percistence.Context;

namespace prueba.Persistence.Repository
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
