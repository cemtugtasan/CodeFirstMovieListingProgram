using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Identity.Client;
using Movie.Model.Models;
using Movies.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DAL.Entity
{
    public class MoviesEntities:DbContext
    {
        public MoviesEntities()
        {

        }
        public MoviesEntities(DbContextOptions<MoviesEntities> option):base(option)
        {

        }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FilmCategory> FilmCategories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-55D3033\MSSQLSERVER01;Database=Market;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            AddSeedAndDatas(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void AddSeedAndDatas(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmCategory>().HasKey(k => new { k.FilmID, k.CategoryID });

            modelBuilder.Entity<Film>().HasData(
                new Film() { FilmID = 1, Name = "Pirates of the Caribbean: The Curse of the Black Pearl", FilmReleaseDate = "2004",PopularityRate= 8},
                new Film() { FilmID = 2, Name = "The Matrix", FilmReleaseDate = "1999",PopularityRate = 9 },
                new Film() { FilmID = 3, Name = "The Godfather", FilmReleaseDate = "1972", PopularityRate = 10 },
                new Film() { FilmID = 4, Name = "YesMan", FilmReleaseDate = "2008", PopularityRate = 6 },
                new Film() { FilmID = 5, Name = "Deadpool", FilmReleaseDate = "2016", PopularityRate = 7 },
                new Film() { FilmID = 6, Name = "Pride&Prejudice", FilmReleaseDate = "2005", PopularityRate = 5 }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryID = 1, Name = "Action" },
                new Category() { CategoryID = 2, Name = "Adventure" },
                new Category() { CategoryID = 3, Name = "Fantastic" },
                new Category() { CategoryID = 4, Name = "Science fiction" },
                new Category() { CategoryID = 5, Name = "Crime" },
                new Category() { CategoryID = 6, Name = "Drama" },
                new Category() { CategoryID = 7, Name = "Comedy" },
                new Category() { CategoryID = 8, Name = "Romantic" }
                );
            modelBuilder.Entity<FilmCategory>().HasData(
                new FilmCategory() { FilmID = 1,CategoryID = 1},
                new FilmCategory() { FilmID = 1, CategoryID = 2 },
                new FilmCategory() { FilmID = 1, CategoryID = 3 },
                new FilmCategory() { FilmID = 1, CategoryID = 6 },
                new FilmCategory() { FilmID = 1, CategoryID = 7 },
                new FilmCategory() { FilmID = 2, CategoryID = 1 },
                new FilmCategory() { FilmID = 2, CategoryID = 3 },
                new FilmCategory() { FilmID = 2, CategoryID = 4 },
                new FilmCategory() { FilmID = 2, CategoryID = 6 },
                new FilmCategory() { FilmID = 3, CategoryID = 1 },
                new FilmCategory() { FilmID = 3, CategoryID = 2 },
                new FilmCategory() { FilmID = 3, CategoryID = 5 },
                new FilmCategory() { FilmID = 3, CategoryID = 6 },
                new FilmCategory() { FilmID = 4, CategoryID = 6 },
                new FilmCategory() { FilmID = 4, CategoryID = 7 },
                new FilmCategory() { FilmID = 4, CategoryID = 8 },
                new FilmCategory() { FilmID = 5, CategoryID = 1 },
                new FilmCategory() { FilmID = 5, CategoryID = 2 },
                new FilmCategory() { FilmID = 5, CategoryID = 3 },
                new FilmCategory() { FilmID = 5, CategoryID = 7 },
                new FilmCategory() { FilmID = 6, CategoryID = 5 },
                new FilmCategory() { FilmID = 6, CategoryID = 6 },
                new FilmCategory() { FilmID = 6, CategoryID = 8 }               
                );
        }
    }
}
