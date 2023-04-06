using BookReviewer.Business.Books.Queries.GetBooksQuery;
using BookReviewer.Models;
using BookReviewer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Authors.Queries.GetAuthorsQuery
{
    public class GetAuthorsQueryQueryHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorsQueryDTO>>
    {
        private readonly BookReviewerDbContext context;

        public GetAuthorsQueryQueryHandler(BookReviewerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<GetAuthorsQueryDTO>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var query = context.Author.AsQueryable();

            //Search by name
            if (request.AuthorName != null)
            {
                query = query.Where(x => x.Name.Contains(request.AuthorName));
            }

            //Search by surname
            if (request.AuthorSurname != null)
            {
                query = query.Where(x => x.Surname.Contains(request.AuthorSurname));
            }

            //Search by year of birth
            if(request.AuthorYearOfBirth != null)
            {
                query = query.Where(x => x.DateOfBirth.Value.Year == request.AuthorYearOfBirth);
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

            var result = await query.Select(x => new GetAuthorsQueryDTO()
            {
                AuthorName = x.Name,
                AuthorSurname = x.Surname,
                AuthorDateOfBirth = x.DateOfBirth.Value.Date,
                AuthorBio = x.Bio
            }).ToListAsync(cancellationToken);

            return result;
        }
    }
}
