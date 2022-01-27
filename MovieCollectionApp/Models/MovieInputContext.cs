using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollectionApp.Models
{
    public class MovieInputContext : DbContext
    {
        public MovieInputContext(DbContextOptions<MovieInputContext> options) : base(options)
        {
            //blank 
        }

        public DbSet<MovieInputModel> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieInputModel>().HasData(

                new MovieInputModel
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "Lord of the Rings - Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = null,
                    Notes = "Best movie ever."
                },
                new MovieInputModel
                {
                    MovieId = 2,
                    Category = "Comedy",
                    Title = "Get Smart",
                    Year = 2008,
                    Director = "Peter Segal",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = "John Doe",
                    Notes = "Funniest movie ever."
                },
                new MovieInputModel
                {
                    MovieId = 3,
                    Category = "Action/Adventure",
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = "Sally",
                    Notes = "Craziest movie ever."
                }
            );
        }
    }
}
