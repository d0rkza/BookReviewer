using BookReviewer.Models;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Books.Commands.EditBookCommand
{
    public class EditBookCommandHandler : IRequestHandler<EditBookCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;

        public EditBookCommandHandler(BookReviewerDbContext context)
        {
            this.context = context;
        }

        public async Task<RecordIDResponse> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            return await this.EditBook(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> EditBook(EditBookCommandParameters parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            var book = await this.context.Book.FirstOrDefaultAsync(x => x.Id == parameters.GetId());

            //Check if book exists
            if (book == null) 
            {
                throw new BaseException("The requested book does not exist. Check Id.");
            }

            book.Title = parameters.BookTitle == null ? book.Title : parameters.BookTitle;
            book.Description = parameters.BookDescription == null ? book.Description : parameters.BookDescription;
            book.ReleaseDate = parameters.BookReleaseDate.HasValue ? parameters.BookReleaseDate.Value : book.ReleaseDate;

            await this.context.SaveChangesAsync(cancellationToken);

            response.SetId(book.Id);
            return response;
        }
    }
}
