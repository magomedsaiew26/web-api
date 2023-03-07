using Microsoft.AspNetCore.Mvc;

using Assignment3.Controllers.Services;
using Assignment3.DTO.Movies;
using Assignment3.Models;




namespace Assignment3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("api/movies")]


    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            var movieDtos = movies.Select(m => new MovieDto(m));
            return Ok(movieDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieDto = new MovieDto(movie);
            return Ok(movieDto);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> Create(MovieCreate createDto)
        {
            var movie = new Movie(createDto.Title, createDto.Genre, createDto.ReleaseYear, createDto.Director, createDto.PictureUrl, createDto.TrailerUrl);
            await _movieService.AddMovieAsync(movie);
            var movieDto = new MovieDto(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movieDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDto>> Update(int id, MovieUpdate updateDto)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
           
            movie.Update(updateDto.Title, updateDto.Genre, updateDto.ReleaseYear, updateDto.Director, updateDto.PictureUrl, updateDto.TrailerUrl);
            await _movieService.UpdateMovieAsync(movie);
            var movieDto = new MovieDto(movie);
            return Ok(movieDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/movies")]
        public async Task<ActionResult<MovieDto>> UpdateMovie(int id, MovieUpdate updateDto)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
             var movies = await _movieService.GetMovieByIdAsync(updateDto.Id);
            movie.UpdateMovie(id, );
            await _movieService.UpdateMovieAsync(movie);
            var movieDto = new MovieDto(movie);
            return Ok(movieDto);
            throw new NotImplementedException();

        }
    }
}

