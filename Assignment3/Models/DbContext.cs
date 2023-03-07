
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Reflection.Emit;
using Assignment3.Models;



namespace Db {
    public class MyCustomDbContext : DbContext
    {
        public MyCustomDbContext(DbContextOptions<MyCustomDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
