using System.Reflection;
using Assignment3.Models;

namespace Assignment3.DTO.Movies
   
{
    public class MovieUpdate
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }
    }
}
