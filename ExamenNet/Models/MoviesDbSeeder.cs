using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.Models
{
    public class MoviesDbSeeder
    {

        public static void Initialize(MoviesDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any movies.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            context.Movies.AddRange(

                new Movie
                {
                    Title = "Movie1",
                    Description = "Description1",
                    Genre = Genre.Action,
                    Duration = 120,
                    ReleaseYear = 2005,
                    Director = "Director1",
                    DateAdded = DateTime.Now,
                    Rating = 5,
                    Watched = Watched.Yes
                }

                );
            context.SaveChanges();



        }
    }
}