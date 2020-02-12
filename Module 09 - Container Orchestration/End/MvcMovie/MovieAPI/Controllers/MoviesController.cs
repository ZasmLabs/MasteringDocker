using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core;
using Models;
using Microsoft.Extensions.Logging;
using System;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IUnitOfWork _uow;
        ILogger<MoviesController> _logger;
        public MoviesController(IUnitOfWork uow, ILogger<MoviesController> logger)
        {
            _uow = uow;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            _logger.LogInformation("public IEnumerable<Movie> Get()");
            IEnumerable<Movie> result = null;
            try
            {
                _logger.LogInformation("public IEnumerable<Movie> Get() _uow.Movies.GetTopFiveMovies");

                result = _uow.Movies.GetTopFiveMovies();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                _logger.LogInformation("public IEnumerable<Movie> Get() finally");
            }
            _logger.LogInformation("public IEnumerable<Movie> Get() return");

            return result;
        }

        [HttpGet("{id}", Name = "Get")]
        public Movie Get(int id)
        {
            return _uow.Movies.Get(id);
        }
    }
}
