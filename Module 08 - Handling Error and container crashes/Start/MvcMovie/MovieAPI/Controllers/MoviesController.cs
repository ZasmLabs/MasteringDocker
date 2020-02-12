using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core;
using Models;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IUnitOfWork _uow;
        public MoviesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _uow.Movies.GetTopFiveMovies();
        }

        [HttpGet("{id}", Name = "Get")]
        public Movie Get(int id)
        {
            return _uow.Movies.Get(id);
        }
    }
}
