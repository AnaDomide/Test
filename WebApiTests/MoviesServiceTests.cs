using ExamenNet.Models;
using ExamenNet.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTests
{
    class MoviesServiceTest
    {

        [Test]
        public void GetAllShouldReturnCorrectNumberOfPagesForMovies()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(GetAllShouldReturnCorrectNumberOfPagesForMovies))
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var movieService = new MoviesService(context);
                var addedFilm = movieService.Create(new ExamenNet.ViewModels.MoviePostModel
                {
                    Title = "film de test 1",
                    Director = "dir1",
                    DateAdded = DateTime.Parse("2019-06-11T00:00:00"),
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

                DateTime from = DateTime.Parse("2019-06-10T00:00:00");
                DateTime to = DateTime.Parse("2019-06-12T00:00:00");

                var allMovies = movieService.GetAll(from, to, 1);
                Assert.AreEqual(1, allMovies.Entries.Count);
            }
        }


        [Test]
        public void GetByIdShouldReturnFilmWithCorrectIdNumber()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(GetByIdShouldReturnFilmWithCorrectIdNumber))
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var movieService = new MoviesService(context);
                var addedMovie = movieService.Create(new ExamenNet.ViewModels.MoviePostModel
                {
                    Title = "Testare",
                    Director = "dir1",
                    DateAdded = new DateTime(),
                    Duration = 100,
                    Description = "asdvadfbdbsb",
                    Genre = "Comedy",
                    ReleaseYear = 2000,
                    Rating = 3,
                    Watched = 0
                }, null);

                var theMovie = movieService.GetById(1);
                Assert.AreEqual("Testare", theMovie.Title);
            }
        }


        [Test]
        public void CreateShouldAddAndReturnTheFilmCreated()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(CreateShouldAddAndReturnTheFilmCreated))
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var movieService = new MoviesService(context);
                var addedMovie = movieService.Create(new ExamenNet.ViewModels.MoviePostModel
                {
                    Title = "Create",
                    Director = "dir1",
                    DateAdded = new DateTime(),
                    Duration = 100,
                    Description = "asdvadfbdbsb",
                    Genre = "Comedy",
                    ReleaseYear = 2000,
                    Rating = 3,
                    Watched = 0
                }, null);

                Assert.IsNotNull(addedMovie);
                Assert.AreEqual("Create", addedMovie.Title);
            }
        }


        //TODO: nu stiu de ce nu functioneaza testul, Postman functioneaza !!!
        [Test]
        public void UpsertShouldChangeTheFildValues()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(UpsertShouldChangeTheFildValues))
              .EnableSensitiveDataLogging()
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var movieService = new MoviesService(context);
                var original = movieService.Create(new ExamenNet.ViewModels.MoviePostModel
                {
                    Title = "Original",
                    Director = "dir1",
                    DateAdded = new DateTime(),
                    Duration = 100,
                    Description = "asdvadfbdbsb",
                    Genre = "Comedy",
                    ReleaseYear = 2000,
                    Rating = 3,
                    Watched = 0
                }, null);


                var movie = new ExamenNet.ViewModels.MoviePostModel
                {
                    Title = "upsert"
                };

                context.Entry(original).State = EntityState.Detached;

                var result = movieService.Upsert(1, movie);

                Assert.IsNotNull(original);
                Assert.AreEqual("upsert", result.Title);
            }
        }

        [Test]
        public void DeleteShouldRemoveAndReturnFilm()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(DeleteShouldRemoveAndReturnFilm))
              .EnableSensitiveDataLogging()
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var filmService = new MoviesService(context);
                var toAdd = filmService.Create(new ExamenNet.ViewModels.MoviePostModel
                {
                    Title = "DeSters",
                    Director = "dir1",
                    DateAdded = new DateTime(),
                    Duration = 100,
                    Description = "asdvadfbdbsb",
                    Genre = "Comedy",
                    ReleaseYear = 2000,
                    Rating = 3,
                    Watched = 0
                }, null);

                Assert.IsNotNull(toAdd);
                Assert.AreEqual(1, filmService.GetAll(new DateTime(), new DateTime(), 1).Entries.Count);

                var deletedFilm = filmService.Delete(1);

                Assert.IsNotNull(deletedFilm);
                Assert.AreEqual(0, filmService.GetAll(new DateTime(), new DateTime(), 1).Entries.Count);
            }
        }


    }
}

