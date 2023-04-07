using BookReviewer.Business.Authors.Queries.GetAuthorDetailsQuery;
using BookReviewer.Business.Authors.Queries.GetAuthorsQuery;
using BookReviewer.Business.Books.Commands.DeleteBookCommand;
using BookReviewer.Business.Books.Commands.EditBookCommand;
using BookReviewer.Business.Books.Commands.NewBookCommand;
using BookReviewer.Business.Books.Queries.GetBooksQuery;
using BookReviewer.IBusiness;
using BookReviewer.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BookReviewer.Api.Controllers
{
    [ApiController]
    [Route("{culture:culture}/[controller]/[action]")]
    public class AuthorController : MediatrController
    {
        /// <summary>
        /// Get list of available authors.
        /// Authors can be retrieved by title.
        /// Authors can be paged with parameters ResultsPerPage and PageNumber.
        /// If PageNumber is not supplied the first n results will be returned (defined by ResultsPerPage)
        /// </summary>
        /// <param name="getAuthorsQuery"></param>
        /// <returns></returns>
        [HttpGet("GetAuthors")]
        public async Task<ActionResult<List<GetAuthorsQueryDTO>>> GetAuthors([FromQuery] GetAuthorsQuery getAuthorsQuery)
        {
            return await this.SendRequest(getAuthorsQuery);
        }

        [HttpGet("GetAuthorDetails")]
        public async Task<ActionResult<GetAuthorDetailsQueryDTO>> GetAuthorDetails([FromQuery] GetAuthorDetailsQuery getAuthorDetailsQuery)
        {
            return await this.SendRequest(getAuthorDetailsQuery);
        }

        ///// <summary>
        ///// Inserts new author to DB and connects entry with author and genre tables.
        ///// New Authors can also be added which get created with this request.
        ///// 
        ///// </summary>
        ///// <param name="newAuthorCommand"></param>
        ///// <returns></returns>
        //[HttpPost("Create")]
        //public async Task<ActionResult<RecordIDResponse>> CreateAuthor(NewAuthorCommand newAuthorCommand)
        //{
        //    var response = await this.SendRequest(newAuthorCommand);
        //    return response;
        //}

        //[HttpPut("{id}/Edit")]
        //public async Task<ActionResult<RecordIDResponse>> EditAuthor(int id, EditAuthorCommand editAuthorCommand)
        //{
        //    editAuthorCommand.Data.SetId(id);
        //    var response = await this.SendRequest(editAuthorCommand);
        //    return response;
        //}

        //[HttpPut("{id}/Delete")]
        //public async Task<ActionResult<RecordIDResponse>> DeleteAuthor(int id, DeleteAuthorCommand deleteAuthorCommand)
        //{
        //    deleteAuthorCommand.Data.SetId(id);
        //    var response = await this.SendRequest(deleteAuthorCommand);
        //    return response;
        //}
    }
}
