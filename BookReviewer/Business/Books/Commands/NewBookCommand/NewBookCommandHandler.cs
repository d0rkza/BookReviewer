using BookReviewer.Models;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Books.Commands.NewBookCommand
{
    public class NewBookCommandHandler : IRequestHandler<NewBookCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;

        public NewBookCommandHandler(BookReviewerDbContext context)
        {
            this.context = context;
        }

        public async Task<RecordIDResponse> Handle(NewBookCommand request, CancellationToken cancellationToken)
        {
            return await this.CreateNewBook(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> CreateNewBook(NewBookCommandParameters parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            //Create new book
            var newBook = new Book()
            {
                Title = parameters.BookTitle,
                Description = parameters.BookDescription,
                ReleaseDate = parameters.BookReleaseDate,
            };

            await this.context.AddAsync(newBook);
            await this.context.SaveChangesAsync();

            //Add existing authors to book_author table
            if(parameters.AuthorIds != null)
            {
                if (parameters.AuthorIds.Count > 0)
                {
                    var authors = await this.context.Author.ToListAsync();
                    foreach (var authorId in parameters.AuthorIds)
                    {
                        if (!authors.Any(x => x.Id == authorId))
                        {
                            throw new BaseException("The requested author does not exists in the database.");
                        }
                        var bookAuthor = new BookAuthor()
                        {
                            AuthorId = authorId,
                            BookId = newBook.Id,
                        };
                        await this.context.AddAsync(bookAuthor);
                    }
                }
            }

            //Add new authors and add them to the book_author table
            if(parameters.Authors != null)
            {
                if (parameters.Authors.Count > 0)
                {
                    foreach (var author in parameters.Authors)
                    {
                        var newAuthor = new Author()
                        {
                            Name = author.Name,
                            Surname = author.Surname,
                            DateOfBirth = author.DateOfBirth,
                            Bio = author.Bio,
                        };

                        await this.context.AddAsync(newAuthor);
                        await this.context.SaveChangesAsync();

                        //Add to book_author table
                        var bookAuthor = new BookAuthor()
                        {
                            AuthorId = newAuthor.Id,
                            BookId = newBook.Id,
                        };
                        await this.context.AddAsync(bookAuthor);
                    }
                }
            }
            
            //Add genres to book
            if(parameters.BookGenres != null)
            {
                if (parameters.BookGenres.Count > 0)
                {
                    var genres = await this.context.Genre.ToListAsync();
                    foreach (var genreId in parameters.BookGenres)
                    {
                        if (!genres.Any(x => x.Id == genreId))
                        {
                            throw new BaseException("The requested author does not exists in the database.");
                        }
                        var bookGenre = new BookGenre()
                        {
                            BookId = newBook.Id,
                            GenreId = genreId,
                        };
                        await this.context.AddAsync(bookGenre);
                    }
                    await this.context.SaveChangesAsync();
                }
            }
            
            response.SetId(newBook.Id);
            return response;
        }
    }
}
