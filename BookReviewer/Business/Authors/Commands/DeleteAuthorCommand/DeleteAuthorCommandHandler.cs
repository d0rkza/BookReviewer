using BookReviewer.Models.Exceptions;
using BookReviewer.Models;
using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookReviewer.Business.BookReviewerService;
using BookReviewer.IBusiness;
using BookReviewer.Models;

namespace BookReviewer.Business.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;
        private readonly IBookReviewerService service;

        public DeleteAuthorCommandHandler(BookReviewerDbContext context, IBookReviewerService service)
        {
            this.context = context;
            this.service = service;
        }

        public async Task<RecordIDResponse> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            this.service.CheckUserPermissions(request.ESign.Username);
            return await this.DeleteAuthor(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> DeleteAuthor(ActionRequest parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            var book = await this.context.Author.FirstOrDefaultAsync(x => x.Id == parameters.GetId());

            if (book == null)
            {
                throw new BaseException("Requested author cannot be found!");
            }

            this.context.Remove(book);
            await this.context.SaveChangesAsync();

            return response;
        }
    }
}
