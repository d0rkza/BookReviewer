using BookReviewer.Localize;
using BookReviewer.Models;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.Extensions.Localization;

namespace BookReviewer.Business.Authors.Commands.NewAuthorCommand
{
    public class NewAuthorCommandHandler : IRequestHandler<NewAuthorCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;
        private readonly IStringLocalizer<Resource> localizer;

        public NewAuthorCommandHandler(BookReviewerDbContext context, IStringLocalizer<Resource> localizer)
        {
            this.context = context;
            this.localizer = localizer;
        }

        public async Task<RecordIDResponse> Handle(NewAuthorCommand request, CancellationToken cancellationToken)
        {
            return await this.CreateNewBook(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> CreateNewBook(NewAuthorCommandParameters parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            //Create new author
            var newAuthor = new Author()
            {
                Name = parameters.AuthorName,
                Surname = parameters.AuthorSurname,
                DateOfBirth = parameters.AuthorDateOfBirth,
                Bio = parameters.AuthorBio,
            };

            await this.context.AddAsync(newAuthor);
            await this.context.SaveChangesAsync();

            response.SetId(newAuthor.Id);
            return response;
        }
    }
}
