using BookReviewer.Localize;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace BookReviewer.Business.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;
        private readonly IStringLocalizer<Resource> localizer;

        public DeleteBookCommandHandler(BookReviewerDbContext context, IStringLocalizer<Resource> localizer)
        {
            this.context = context;
            this.localizer = localizer;
        }

        public async Task<RecordIDResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await this.DeleteBook(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> DeleteBook(ActionRequest parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            var book = await this.context.Book.FirstOrDefaultAsync(x => x.Id == parameters.GetId());

            if (book == null)
            {
                throw new BaseException(localizer["DELETE_BOOK_BOOK_NOT_FOUND"]);
            }

            this.context.Remove(book);
            await this.context.SaveChangesAsync();

            return response;
        }
    }
}
