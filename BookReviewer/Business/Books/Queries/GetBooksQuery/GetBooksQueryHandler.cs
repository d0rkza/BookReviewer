using BookReviewer.Models;
using BookReviewer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Books.Queries.GetBooksQuery
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<GetBooksQueryDTO>>
    {
        private readonly BookReviewerDbContext context;

        public GetBooksQueryHandler(BookReviewerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<GetBooksQueryDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var query = context.Book.AsQueryable();

            //If we request
            if (request.BookTitle != null)
            {
                query = query.Where(x => x.Title.Contains(request.BookTitle));
            }

            //Get list of books per page if paging is requested
            if (request.ResultsPerPage != null)
            {
                if (request.PageNumber != null)
                {
                    int startResult = request.ResultsPerPage.Value * (request.PageNumber.Value - 1);
                    query = query.OrderBy(x => x.Id)
                        .Skip(startResult)
                        .Take(request.ResultsPerPage.Value);
                }
                else
                {
                    query = query.OrderBy(x => x.Id)
                        .Take(request.ResultsPerPage.Value);
                }
            }

            var result = await query.Select(x => new GetBooksQueryDTO()
            {
                BookId = x.Id,
                BookTitle = x.Title,
                BookDescription = x.Description,
                BookReleaseDate = x.ReleaseDate,
            }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
