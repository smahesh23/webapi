using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _moviesContext;

        public MoviesController(MovieContext moviesContext)
        {
            this._moviesContext = moviesContext;
        }

        [HttpGet]
        public IActionResult GetMovies() 
        {
            return Ok(_moviesContext.Movies);
        }
    }
}
