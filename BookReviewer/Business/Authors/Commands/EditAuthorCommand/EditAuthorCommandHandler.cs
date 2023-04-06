using BookReviewer.Models.Exceptions;
using BookReviewer.Models;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BookReviewer.Models;

namespace BookReviewer.Business.Authors.Commands.EditAuthorCommand
{
    public class EditAuthorCommandHandler : IRequestHandler<EditAuthorCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;

        public EditAuthorCommandHandler(BookReviewerDbContext context)
        {
            this.context = context;
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
                throw new BaseException("The requested author does not exist. Check Id.");
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
