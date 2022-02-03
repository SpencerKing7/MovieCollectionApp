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

        public DbSet<MovieInputModel> Responses { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        //Seed Data
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryId = 1, CategoryName="Action/Adventure"},
                new CategoryModel { CategoryId = 2, CategoryName = "Comedy" },
                new CategoryModel { CategoryId = 3, CategoryName = "Drama" },
                new CategoryModel { CategoryId = 4, CategoryName = "Family" },
                new CategoryModel { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new CategoryModel { CategoryId = 6, CategoryName = "Miscellaneous" },
                new CategoryModel { CategoryId = 7, CategoryName = "Television" },
                new CategoryModel { CategoryId = 8, CategoryName = "VHS" }
            );

            mb.Entity<MovieInputModel>().HasData(

                new MovieInputModel
                {
                    MovieId = 1,
                    CategoryId = 1,
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
                    CategoryId = 2,
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
                    CategoryId = 1,
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
