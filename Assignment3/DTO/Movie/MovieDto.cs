using Assignment3.Models;
using System;

namespace Assignment3.DTO.Movies
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }
        public Models.Movie Movie { get; }

        public MovieDto(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            Id = movie.Id;
            Title = movie.Title;
            Genre = movie.Genre;
            ReleaseYear = movie.ReleaseYear;
            Director = movie.Director;
            PictureUrl = movie.PictureUrl;
            TrailerUrl = movie.TrailerUrl;
        }

    }
}
