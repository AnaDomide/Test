using ExamenNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.ViewModels
{
    public class MoviePostModel
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public DateTime DateAdded { get; set; }
        public int Rating { get; set; }
        [EnumDataType(typeof(Watched))]
        public Watched Watched { get; set; }

        public List<Comment> Comments { get; set; } // adaugat de mine


        public static Movie ToMovie(MoviePostModel movie)
        {
            Genre genre = ExamenNet.Models.Genre.Action;

            if (movie.Genre == "Comedy")
            {
                genre = ExamenNet.Models.Genre.Comedy;
            }
            else if (movie.Genre == "Horror")
            {
                genre = ExamenNet.Models.Genre.Horror;
            }
            else if (movie.Genre == "Thriler")
            {
                genre = ExamenNet.Models.Genre.Thriler;
            }

            return new Movie
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = genre,
                Duration = movie.Duration,
                ReleaseYear = movie.ReleaseYear,
                DateAdded = movie.DateAdded,
                Director = movie.Director,
                Rating = movie.Rating,
                Watched = movie.Watched,
                Comments = movie.Comments
            };
        }


    }
}
