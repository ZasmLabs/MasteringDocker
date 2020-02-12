using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        IHttpClientFactory _clientFactory;
        public MoviesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<ViewResult> Index()
        {
            ViewBag.LocalIpAddress = HttpContext.Request.HttpContext.Connection.LocalIpAddress;

            var client = _clientFactory.CreateClient("movies");
            var response = await client.GetAsync("/api/movies");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonSerializer.
                Deserialize<IEnumerable<Movie>>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(movies);
        }
    }
}