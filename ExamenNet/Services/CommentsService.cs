using ExamenNet.Models;
using ExamenNet.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNet.Services
{

    public interface ICommentsService
    {
        PaginatedList<CommentGetModel> GetAll(string contine, int page);
    }


    public class CommentsService : ICommentsService
    {
        private MoviesDbContext context;

        public CommentsService(MoviesDbContext context)
        {
            this.context = context;
        }


        public PaginatedList<CommentGetModel> GetAll(string filterString, int page)
        {
            IQueryable<Comment> result = context
                .Comments
                .Where(c => string.IsNullOrEmpty(filterString) || c.Text.Contains(filterString))
                .OrderBy(c => c.Id)
                .Include(c => c.Movie);

            PaginatedList<CommentGetModel> paginatedResult = new PaginatedList<CommentGetModel>();
            paginatedResult.CurrentPage = page;

            paginatedResult.NumberOfPages = (result.Count() - 1) / PaginatedList<CommentGetModel>.EntriesPerPage + 1;
            result = result
                .Skip((page - 1) * PaginatedList<CommentGetModel>.EntriesPerPage)
                .Take(PaginatedList<CommentGetModel>.EntriesPerPage);
            paginatedResult.Entries = result.Select(f => CommentGetModel.FromComment(f)).ToList();

            return paginatedResult;

        }
    }
}
