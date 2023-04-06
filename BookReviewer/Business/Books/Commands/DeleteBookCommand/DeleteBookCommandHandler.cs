using BookReviewer.IBusiness;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Business.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;
        private readonly IBookReviewerService service;


        public DeleteBookCommandHandler(BookReviewerDbContext context, IBookReviewerService service)
        {
            this.context = context;
            this.service = service;
        }

        public async Task<RecordIDResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            //this.service.CheckUserPermissions(request.ESign.Username);
            return await this.DeleteBook(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> DeleteBook(ActionRequest parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            var book = await this.context.Book.FirstOrDefaultAsync(x => x.Id == parameters.GetId());

            if (book == null)
            {
                throw new BaseException("Requested book cannot be found!");
            }

            this.context.Remove(book);
            await this.context.SaveChangesAsync();

            return response;
        }
    }
}
