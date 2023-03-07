


using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public DbSet<MovieCharacter> MovieCharacters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Franchises
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise { Id = 1, Name = "Marvel Cinematic Universe", FoundedYear = 2008 },
                new Franchise { Id = 2, Name = "Star Wars", FoundedYear = 1977 },
                new Franchise { Id = 3, Name = "Harry Potter", FoundedYear = 2001 }
            );

            // Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Iron Man", ReleaseYear = 2008, FranchiseId = 1 },
                new Movie { Id = 2, Title = "Captain America: The First Avenger", ReleaseYear = 2011, FranchiseId = 1 },
                new Movie { Id = 3, Title = "Star Wars: A New Hope", ReleaseYear = 1977, FranchiseId = 2 },
                new Movie { Id = 4, Title = "Harry Potter and the Philosopher's Stone", ReleaseYear = 2001, FranchiseId = 3 }
            );

            // Characters
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, FullName = "Tony Stark", Alias = "Iron Man", Gender = "Male", PictureUrl = "https://www.example.com/ironman.jpg" },
                new Character { Id = 2, FullName = "Steve Rogers", Alias = "Captain America", Gender = "Male", PictureUrl = "https://www.example.com/captainamerica.jpg" },
                new Character { Id = 3, FullName = "Luke Skywalker", Alias = null, Gender = "Male", PictureUrl = "https://www.example.com/lukeskywalker.jpg" },
                new Character { Id = 4, FullName = "Hermione Granger", Alias = null, Gender = "Female", PictureUrl = "https://www.example.com/hermione.jpg" }
            );

            // Movie-Character relationships
            modelBuilder.Entity<MovieCharacter>()
                .HasData(
                    new MovieCharacter { CharacterId = 1, MovieId = 1 },
                    new MovieCharacter { CharacterId = 2, MovieId = 1 },
                    new MovieCharacter { CharacterId = 2, MovieId = 2 },
                    new MovieCharacter { CharacterId = 3, MovieId = 3 },
                    new MovieCharacter { CharacterId = 4, MovieId = 4 }
                );

            // Characters

            modelBuilder.Entity<Character>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Character>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Character>()
                .Property(c => c.FullName)
                .IsRequired();

            modelBuilder.Entity<Character>()
                .Property(c => c.Alias);

            modelBuilder.Entity<Character>()
                .Property(c => c.Gender)
                .IsRequired();

            modelBuilder.Entity<Character>()
                .Property(c => c.PictureUrl);

            // Movies

            modelBuilder.Entity<Movie>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Franchise)
                .WithMany(f => f.Movies)
                .HasForeignKey(m => m.FranchiseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCharacter",
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                    });

            // Franchises

            modelBuilder.Entity<Franchise>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Franchise>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Franchise>()
                .Property(f => f.Name)
                .IsRequired();
        }
    }

    public class Character
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Alias { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public Movie(string title, string genre, string releaseYear, string director, string pictureUrl, string trailerUrl)
        {
            Title = title;
            Genre = genre;
            ReleaseYear1 = releaseYear;
            Director = director;
            PictureUrl = pictureUrl;
            TrailerUrl = trailerUrl;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }

        public int ReleaseYear { get; set; }
        public ICollection<Character> Characters { get; set; }
        public string Genre { get; }
        public string ReleaseYear1 { get; }
        public string Director { get; }
        public string PictureUrl { get; }
        public string TrailerUrl { get; }

        internal void Update(string title, string genre, string releaseYear, string director, string pictureUrl, string trailerUrl)
        {
            throw new NotImplementedException();
        }
    }

    public class Franchise
    {
        public Franchise(string name, string description)
        {
            Name = name;
            Description = description;

        }


    public int Id { get; set; }
        public string Name { get; set; }

        public int FoundedYear { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public string Description { get; }

        internal void Update(string name, string description)
        {
            throw new NotImplementedException();
        }
    }

    public class MovieCharacter
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}

