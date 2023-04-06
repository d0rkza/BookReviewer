using BookReviewer.Business.Books.Commands.NewBookCommand;
using BookReviewer.Models;
using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Books.Commands.EditBookCommand
{
    public class EditBookCommandParameters : ActionRequest
    {
        public string? BookTitle { get; set; }
        public DateTime? BookReleaseDate { get; set; }
        public string? BookDescription { get; set; }
    }
    public class EditBookCommand : ESignRequest<EditBookCommandParameters, RecordIDResponse>
    {
    }
}
