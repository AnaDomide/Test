using ExamenNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.ViewModels
{


    public class MovieGetModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public DateTime DateAdded { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public int Rating { get; set; }
        public Watched Watched { get; set; }
        public int NumberOfComments { get; set; }



        public static MovieGetModel FromMovie(Movie movie)
        {
            return new MovieGetModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                DateAdded = movie.DateAdded,
                Director = movie.Director,
                Duration = movie.Duration,
                Rating = movie.Rating,
                ReleaseYear = movie.ReleaseYear,
                Watched = movie.Watched,
               // NumberOfComments = movie.Comments.Count
            };
        }


    }
}
