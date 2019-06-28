using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenNet.Models;
using ExamenNet.Services;
using ExamenNet.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private IMoviesService moviesService;

        private IUsersService usersService;
        public MoviesController(IMoviesService moviesService, IUsersService usersService )
        {
            this.moviesService = moviesService;
            this.usersService = usersService;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <param name="from"> Optional,filter by minimum data</param>
        /// <param name="to">Optional,filter by maximum date</param>
        /// <param name="page">Optional,filter by page</param>
        /// <remarks>
        /// Sample response:
        ///
        ///     Get /movies
        ///     {  id: 3,
        ///        title: "Movie3",
        ///        description: "Descriptiin3",
        ///        genre: 2,
        ///        dateAdded: "2019-05-12T00:00:00",
        ///        duration: 120,
        ///        releaseYear: 2010,
        ///        director: "Director3",
        ///        rating: 8,
        ///        watched: 1,
        ///        comentarii: [
        ///            {
        ///                    id: 1,
        ///                    text: "great movie",
        ///                    important: false
        ///             },
        ///             {
        ///                   id: 2,
        ///                   text: "bad movie",
        ///                   important: false
        ///             }
        ///         ]
        ///     }
        ///
        ///          </remarks>
        ///          <returns>List with all movies</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public PaginatedList<MovieGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to, [FromQuery]int page = 1)
        {
            page = Math.Max(page, 1);
            return moviesService.GetAll(from, to, page);
        }

        /// <summary>
        /// Get movie by Id
        /// </summary>
        /// <param name="id">Optional,filter by Id</param>
        ///  <remarks>
        /// Sample response:
        ///
        ///     Get /movies
        ///     {  id: 3,
        ///        title: "Title3",
        ///        description: "Description3",
        ///        genre: 2,
        ///        dateAdded: "2019-05-12T00:00:00",
        ///        duration: 120,
        ///        releaseYear: 2010,
        ///        director: "Director3",
        ///        rating: 8,
        ///        watched: 1,
        ///        comentarii: [
        ///     {
        ///         id: 1,
        ///         text: "great movie"
        ///     },
        ///     {
        ///         id: 2,
        ///         text: "bad movie"
        ///     }
        ///     ]
        ///     }
        ///
        ///          </remarks>
        /// <returns>The wanted movie</returns>
        [ProducesResponseType(StatusCodes.Status200OK)] //adaugat de mine
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetMovies")]
        public IActionResult Get(int id)
        {
            var found = moviesService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        /// <summary>
        /// Add movie to database
        /// </summary>
        /// <param name="movie">Object of type movie</param>
        ///  <remarks>
        /// Sample request:
        ///
        ///     Post /movies
        ///      {  title: "Movie3",
        ///        description: "Description3",
        ///        genre: "Action",
        ///        dateAdded: "2019-05-12T00:00:00",
        ///        duration: 120,
        ///        releaseYear: 2010,
        ///        director: "Director3",
        ///        rating: 8,
        ///        watched: 1,
        ///          comentarii: [
        ///     {
        ///         id: 1,
        ///         text: "great movie"
        ///     },
        ///     {
        ///         id: 2,
        ///         text: "great movie"
        ///     }
        ///     ]        
        ///}
        ///</remarks>
        ///        <returns>The added movie</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize(Roles ="Admin,Regular")]    
        [HttpPost]
        public void Post([FromBody] MoviePostModel movie)
        {
            User addedBy = usersService.GetCurentUser(HttpContext);

            ////if(addedBy.UserRole == UserRole.UserManager)
           // //{
           // //    return Forbid();      //trebuie returnat tipul IActionResult
           // //}

            moviesService.Create(movie, addedBy);
        }

        /// <summary>
        /// Updates existing movie from database
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="movie">Object of type movie</param>
        /// Sample request:
        ///     <remarks>
        ///     Post /movies
        ///      {  title: "Movie3",
        ///        description: "Description",
        ///        genre: "Action",
        ///        dateAdded: "2019-05-12T00:00:00",
        ///        duration: 120,
        ///        releaseYear: 2010,
        ///        director: "Director3",
        ///        rating: 8,
        ///        watched: 1,
        ///     }
        ///        </remarks>
        /// <returns>Status 200 if it was modified</returns>
        /// <returns>Status 400 if modification not possible</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize(Roles = "Admin,Regular")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MoviePostModel movie)
        {
            var result = moviesService.Upsert(id, movie);
            return Ok(result);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
       // [Authorize(Roles = "Admin,Regular")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = moviesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}