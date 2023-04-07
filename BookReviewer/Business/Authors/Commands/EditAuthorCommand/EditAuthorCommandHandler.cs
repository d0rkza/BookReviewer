using BookReviewer.Models.Exceptions;
using BookReviewer.Models;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BookReviewer.Localize;
using Microsoft.Extensions.Localization;

namespace BookReviewer.Business.Authors.Commands.EditAuthorCommand
{
    public class EditAuthorCommandHandler : IRequestHandler<EditAuthorCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;
        private readonly IStringLocalizer<Resource> localizer;

        public EditAuthorCommandHandler(BookReviewerDbContext context, IStringLocalizer<Resource> localizer)
        {
            this.context = context;
            this.localizer = localizer;
        }

        public async Task<RecordIDResponse> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
        {
            return await this.EditAuthor(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> EditAuthor(EditAuthorCommandParameters parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            var author = await this.context.Author.FirstOrDefaultAsync(x => x.Id == parameters.GetId());

            //Check if book exists
            if (author == null)
            {
                throw new BaseException(localizer["NEW_BOOK_AUTHOR_NOT_FOUND"]);
            }

            author.Name = parameters.AuthorName == null ? author.Name : parameters.AuthorName;
            author.Surname = parameters.AuthorSurname == null ? author.Surname : parameters.AuthorSurname;
            author.Bio = parameters.AuthorBio == null ? author.Bio : parameters.AuthorBio;
            author.DateOfBirth = parameters.AuthorDateOfBirth.HasValue ? parameters.AuthorDateOfBirth.Value : author.DateOfBirth;

            await this.context.SaveChangesAsync(cancellationToken);

            response.SetId(author.Id);
            return response;
        }
    }
}
