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
using BookReviewer.Localize;
using Microsoft.Extensions.Localization;

namespace BookReviewer.Business.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;
        private readonly IStringLocalizer<Resource> localizer;

        public DeleteAuthorCommandHandler(BookReviewerDbContext context, IStringLocalizer<Resource> localizer)
        {
            this.context = context;
            this.localizer = localizer;
        }

        public async Task<RecordIDResponse> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return await this.DeleteAuthor(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> DeleteAuthor(ActionRequest parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            var book = await this.context.Author.FirstOrDefaultAsync(x => x.Id == parameters.GetId());

            if (book == null)
            {
                throw new BaseException(localizer["DELETE_AUTHOR_AUTHOR_NOT_FOUND"]);
            }

            this.context.Remove(book);
            await this.context.SaveChangesAsync();

            return response;
        }
    }
}
