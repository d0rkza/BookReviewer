using BookReviewer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookReviewer.Business.Books.Queries.GetBooksQuery
{
    public class GetBooksQuery : IRequest<List<GetBooksQueryDTO>>
    {
        public string? BookTitle { get; set; }
        public int? ResultsPerPage { get; set; }
        public int? PageNumber { get; set; }
    }
}
