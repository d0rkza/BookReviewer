using BookReviewer.Business.Books.Queries.GetBooksQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Authors.Queries.GetAuthorsQuery
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorsQueryDTO>>
    {
        public string? AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public int? AuthorYearOfBirth { get; set; }
        public int? ResultsPerPage { get; set; }
        public int? PageNumber { get; set; }
    }
}
