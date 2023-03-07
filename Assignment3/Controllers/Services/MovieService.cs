using Assignment3.Controllers.Services;
using Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Controllers.Services
{
    public class MovieService : IMovieService
    {
        private readonly MyDbContext _dbContext;

        public MovieService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }


        public async Task<Movie> GetMovieByIdListAsync(int id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _dbContext.Movies.ToListAsync();
        }
      


        public async Task AddMovieAsync(Movie movie)
        {
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
