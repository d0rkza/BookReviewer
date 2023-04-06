using BookReviewer.Models;
using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Books.Commands.NewBookCommand
{
    public class NewBookCommandParameters
    {
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public DateTime BookReleaseDate { get; set; }
        [Required]
        public string BookDescription { get; set; }

        public List<int>? AuthorIds { get; set; }

        public List<Author>? Authors { get; set; }

        public List<int>? BookGenres { get; set; }
    }

    public class NewBookCommand : ESignRequest<NewBookCommandParameters, RecordIDResponse>
    {
    }
}
