using BookReviewer.Models;
using BookReviewer.Models;
using BookReviewer.Models.Responses;
using MediatR;

namespace BookReviewer.Business.Authors.Commands.NewAuthorCommand
{
    public class NewAuthorCommandHandler : IRequestHandler<NewAuthorCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;

        public NewAuthorCommandHandler(BookReviewerDbContext context)
        {
            this.context = context;
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
