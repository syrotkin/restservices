using System.Collections.Generic;
using System.Web.Http;

using Common;
using Common.Model;

namespace ProductsApp.Controllers
{
    public class MoviesController : ApiController
    {
        // matches /api/movies
        [HttpGet]
        public IEnumerable<Movie> ListAllMovies() {
            var business = new MovieBusiness();
            var movies = business.ListMoviesByNameAndGenre(null, null);
            return movies;
        }
        
        // matches /api/movies?name=xxxx
        [HttpGet]
        public IHttpActionResult SearchMovieByName(string name) {
            var business = new MovieBusiness();
            var movies = business.ListMoviesByNameAndGenre(name, null);

            return Ok(movies);
        }
    }
}
