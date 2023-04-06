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

namespace BookReviewer.Business.Authors.Commands.NewAuthorCommand
{
    public class NewAuthorCommandParameters
    {
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string AuthorSurname { get; set; }
        [Required]
        public DateTime AuthorDateOfBirth { get; set; }
        [Required]
        public string AuthorBio { get; set; }
    }
    public class NewAuthorCommand : ESignRequest<NewAuthorCommandParameters, RecordIDResponse>
    {
    }
}
