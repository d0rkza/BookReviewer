using BookReviewer.Business.Books.Commands.DeleteBookCommand;
using BookReviewer.Business.Books.Commands.EditBookCommand;
using BookReviewer.Business.Books.Commands.NewBookCommand;
using BookReviewer.Business.Books.Queries.GetBookDetailsQuery;
using BookReviewer.Business.Books.Queries.GetBooksQuery;
using BookReviewer.IBusiness;
using BookReviewer.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BookReviewer.Api.Controllers
{
    [ApiController]
    [Route("{culture:culture}/[controller]/[action]")]
    public class BookController : MediatrController
    {
        /// <summary>
        /// Get list of available books.
        /// Books can be retrieved by title.
        /// Books can be paged with parameters ResultsPerPage and PageNumber.
        /// If PageNumber is not supplied the first n results will be returned (defined by ResultsPerPage)
        /// </summary>
        /// <param name="getBooksQuery"></param>
        /// <returns></returns>
        [HttpGet("GetBooks")]
        public async Task<ActionResult<List<GetBooksQueryDTO>>> GetBooks([FromQuery] GetBooksQuery getBooksQuery)
        {
            string authHeader = HttpContext.Request.Headers["Authorization"];
            string token = authHeader?.Split(" ").Last();

            Response.Headers.Add("Authorization", $"Bearer {token}");
            
            return await this.SendRequest(getBooksQuery);
        }

        [HttpGet("GetBookDetails")]
        public async Task<ActionResult<GetBookDetailsQueryDTO>> GetBookDetails([FromQuery]GetBookDetailsQuery getBookDetails)
        {
            return await this.SendRequest(getBookDetails);
        }

        /// <summary>
        /// Inserts new book to DB and connects entry with author and genre tables.
        /// New Authors can also be added which get created with this request.
        /// 
        /// </summary>
        /// <param name="newBookCommand"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<RecordIDResponse>> CreateBook(NewBookCommand newBookCommand)
        {
            var response = await this.SendRequest(newBookCommand);
            return response;
        }

        [Authorize]
        [HttpPut("{id}/Edit")]
        public async Task<ActionResult<RecordIDResponse>> EditBook(int id, EditBookCommand editBookCommand)
        {
            editBookCommand.Data.SetId(id);
            var response = await this.SendRequest(editBookCommand);
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/Delete")]
        public async Task<ActionResult<RecordIDResponse>> DeleteBook(int id, DeleteBookCommand deleteBookCommand)
        {
            deleteBookCommand.Data.SetId(id);
            return await this.SendRequest(deleteBookCommand);
        }
    }
}
