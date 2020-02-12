using Core;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        MvcMovieContext _context;
        public MovieRepository(MvcMovieContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetTopFiveMovies()
        {
            return _context.Movie.Take(5).ToList();
        }
    }
}
