using BookReviewer.Localize;
using BookReviewer.Models;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<Resource> localizer;

        public EditBookCommandHandler(BookReviewerDbContext context, IStringLocalizer<Resource> localizer)
        {
            this.context = context;
            this.localizer = localizer;
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
                throw new BaseException(localizer["EDIT_BOOK_BOOK_NOT_FOUND"]);
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
