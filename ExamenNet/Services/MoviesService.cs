using ExamenNet.Models;
using ExamenNet.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.Services
{

    public interface IMoviesService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        PaginatedList<MovieGetModel> GetAll(DateTime? from, DateTime? to, int page);
        Movie GetById(int id);
        Movie Create(MoviePostModel film, User addedBy);
        Movie Upsert(int id, MoviePostModel film);
        Movie Delete(int id);
    }



    public class MoviesService : IMoviesService
    {
        private MoviesDbContext context;
        public MoviesService(MoviesDbContext context)
        {
            this.context = context;
        }

        public Movie Create(MoviePostModel movie, User addedBy)
        {
            Movie toAdd = MoviePostModel.ToMovie(movie);
            toAdd.Owner = addedBy;      //adaugam persoana care a adaugat acest Movie movie
            context.Movies.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Movie Delete(int id)
        {
            var existing = context
                .Movies
                .Include(f => f.Comments)
                .FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return null;
            }

            ////o varianta de asterge comentariile unui Movie
            //foreach(var comment in existing.Comments)
            //{
            //    context.Comments.Remove(comment);
            //}

            context.Movies.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public PaginatedList<MovieGetModel> GetAll(DateTime? from, DateTime? to, int page)
        {
            IQueryable<Movie> result = context
                .Movies
                .OrderBy(f => f.Id)
                .Include(f => f.Comments);

            PaginatedList<MovieGetModel> paginatedResult = new PaginatedList<MovieGetModel>();
            paginatedResult.CurrentPage = page;

            if (from != null)
            {
                result = result.Where(f => f.DateAdded >= from);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }

            paginatedResult.NumberOfPages = (result.Count() - 1) / PaginatedList<MovieGetModel>.EntriesPerPage + 1;
            result = result
                .Skip((page - 1) * PaginatedList<MovieGetModel>.EntriesPerPage)
                .Take(PaginatedList<MovieGetModel>.EntriesPerPage);
            paginatedResult.Entries = result.Select(f => MovieGetModel.FromMovie(f)).ToList();

            return paginatedResult;
        }


        public Movie GetById(int id)
        {
            return context.Movies
                .Include(f => f.Comments)
                .FirstOrDefault(f => f.Id == id);
        }

        public Movie Upsert(int id, MoviePostModel movie)
        {
            var existing = context
                .Movies
                .AsNoTracking().FirstOrDefault(f => f.Id == id);

            //context.Entry(existing).State = EntityState.Detached;

            if (existing == null)
            {
                Movie toAdd = MoviePostModel.ToMovie(movie);
                context.Movies.Add(toAdd);
                context.SaveChanges();
                return toAdd;
            }

            Movie toUpdate = MoviePostModel.ToMovie(movie);
            toUpdate.Id = id;
            context.Movies.Update(toUpdate);
            context.SaveChanges();
            return toUpdate;
        }
    }
}
