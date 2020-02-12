using Models;
using System.Collections.Generic;

namespace Core
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetTopFiveMovies();
    }
}
