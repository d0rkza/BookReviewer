using BookReviewer.Localize;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace BookReviewer.Business.Authors.Queries.GetAuthorDetailsQuery
{
    public class GetAuthorDetailsQueryQueryHandler : IRequestHandler<GetAuthorDetailsQuery, GetAuthorDetailsQueryDTO>
    {
        private readonly BookReviewerDbContext context;
        private readonly IStringLocalizer<Resource> localizer;

        public GetAuthorDetailsQueryQueryHandler(BookReviewerDbContext context, IStringLocalizer<Resource> localizer)
        {
            this.context = context;
            this.localizer = localizer;
        }

        public async Task<GetAuthorDetailsQueryDTO> Handle(GetAuthorDetailsQuery request, CancellationToken cancellationToken)
        {
            var author = await this.context.Author.FirstOrDefaultAsync(x => x.Id == request.AuthorId);

            if (author == null) throw new BaseException(localizer["GET_AUTHOR_AUTHOR_NOT_FOUND"]);

            var booksByAuthor = from book in this.context.Book
                                join bookAuthor in this.context.BookAuthor
                                on book.Id equals bookAuthor.BookId
                                where bookAuthor.AuthorId == request.AuthorId
                                select book;

            List<Book> books = booksByAuthor.ToList();

            var genreByAuthor = from genre in this.context.Genre
                                join genreAuthor in this.context.AuthorGenre
                                on genre.Id equals genreAuthor.GenreId
                                where genreAuthor.AuthorId == request.AuthorId
                                select genre;

            List<Genre> genres = genreByAuthor.ToList();

            var result = new GetAuthorDetailsQueryDTO()
            {
                AuthorName = author.Name,
                AuthorSurname = author.Surname,
                AuthorDateOfBirth = author.DateOfBirth,
                AuthorBio = author.Bio,

                Books = books,
                Genres = genres,
            };

            return result;
        }
    }
}
