using ExamenNet.Models;
using ExamenNet.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTests
{
    class CommentsServiceTest
    {
        [Test]
        public void GetAllShouldReturnCorrectNumberOfPages()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(GetAllShouldReturnCorrectNumberOfPages))
              .Options;

            using (var context = new MoviesDbContext(options))
            {

                var commentService = new CommentsService(context);
                var movieService = new MoviesService(context);
                var addedMovie = movieService.Create(new ExamenNet.ViewModels.MoviePostModel
                {
                    Title = "film de test 1",
                    Director = "dir1",
                    DateAdded = new DateTime(),
                    Duration = 100,
                    Description = "asdvadfbdbsb",
                    Genre = "Comedy",
                    ReleaseYear = 2000,
                    Rating = 3,
                    Watched = 0,
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Important = true,
                            Text = "asd",
                            AddedBy = null
                        }
                    },

                }, null);

                var allComments = commentService.GetAll(string.Empty, 1);
                Assert.AreEqual(1, allComments.NumberOfPages);
            }
        }
    }
}
