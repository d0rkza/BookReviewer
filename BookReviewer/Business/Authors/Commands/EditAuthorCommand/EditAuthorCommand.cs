using BookReviewer.Business.Books.Commands.EditBookCommand;
using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Authors.Commands.EditAuthorCommand
{
    public class EditAuthorCommandParameters : ActionRequest
    {
        public string? AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public DateTime? AuthorDateOfBirth { get; set; }
        public string? AuthorBio { get; set; }
    }
    public class EditAuthorCommand : ESignRequest<EditAuthorCommandParameters, RecordIDResponse>
    {
    }
}