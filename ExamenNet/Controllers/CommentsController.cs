using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenNet.Services;
using ExamenNet.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentsService commentService;

        public CommentsController(ICommentsService commentService)
        {
            this.commentService = commentService;
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <param name="filterString">Optional,filter by string</param>
        /// <param name="page">Optional,filter by page</param>
        /// <remarks>
        /// Sample response:   
        ///      {
        ///         id: 3,
        ///         text: "another comment",
        ///         idMovie: 2
        ///         }
        /// </remarks>
        /// 
        /// <returns>List with comments</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public PaginatedList<CommentGetModel> Get([FromQuery]string filterString, [FromQuery]int page = 1)
        {
            return commentService.GetAll(filterString, page);
        }


    }
}