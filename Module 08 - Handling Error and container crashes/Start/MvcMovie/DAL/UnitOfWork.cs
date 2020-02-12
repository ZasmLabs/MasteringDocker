using Core;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        MvcMovieContext _context;
        public UnitOfWork(MvcMovieContext context, IMovieRepository movies)
        {
            _context = context;
            Movies = movies;
        }

        public IMovieRepository Movies { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
