using BookReviewer.Localize;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;

namespace BookReviewer.Business.Books.Queries.GetBookDetailsQuery
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, GetBookDetailsQueryDTO>
    {
        private readonly BookReviewerDbContext context;
        private readonly IStringLocalizer<Resource> localizer;

        public GetBookDetailsQueryHandler(BookReviewerDbContext context, IStringLocalizer<Resource> localizer)
        {
            this.context = context;
            this.localizer = localizer;
        }

        public async Task<GetBookDetailsQueryDTO> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request.BookId == null) 
            {
                throw new BaseException(localizer["GET_BOOK_DETAILS_NO_ID"]);
            }

            var result = context.Book
            .Where(b => b.Id == request.BookId)
            .Select(b => new GetBookDetailsQueryDTO
            {
                BookId = b.Id,
                BookTitle = b.Title,
                BookDescription = b.Description,
                BookReleaseDate = b.ReleaseDate,
                Authors = context.BookAuthor
                    .Where(ba => ba.BookId == b.Id)
                    .Select(ba => ba.Author)
                    .ToList(),
                Genres = context.BookGenre
                    .Where(bg => bg.BookId == b.Id)
                    .Select(bg => bg.Genre)
                    .ToList()
            })
            .FirstOrDefault();

            if (result == null)
            {
                throw new BaseException(localizer["GET_BOOK_DETAILS_BOOK_DETAILS_NOT_FOUND"]);
            }

            return result;
        }
    }
}
