using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using MediatR;

namespace BookReviewer.Business.Books.Queries.GetBookDetailsQuery
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, GetBookDetailsQueryDTO>
    {
        private readonly BookReviewerDbContext context;

        public GetBookDetailsQueryHandler(BookReviewerDbContext context)
        {
            this.context = context;
        }

        public async Task<GetBookDetailsQueryDTO> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request.BookId == null) 
            {
                throw new BaseException("Please provide book id");
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
                throw new BaseException("Book details were not found.");
            }

            return result;
        }
    }
}
