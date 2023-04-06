using BookReviewer.Business.Books.Commands.NewBookCommand;
using BookReviewer.Models.Exceptions;
using BookReviewer.Models;
using BookReviewer.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReviewer.Business.BookReviewerService;
using BookReviewer.IBusiness;
using BookReviewer.Models;

namespace BookReviewer.Business.Users.Commands.RegisterUserCommand
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RecordIDResponse>
    {
        private readonly BookReviewerDbContext context;
        private readonly IBookReviewerService service;
        private readonly ICustomAuthenticationService authenticationService;

        public RegisterUserCommandHandler(BookReviewerDbContext context, IBookReviewerService service, ICustomAuthenticationService authenticationService)
        {
            this.context = context;
            this.service = service;
            this.authenticationService = authenticationService;
        }

        public async Task<RecordIDResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await this.CreateNewUser(request.Data, cancellationToken);
        }

        public async Task<RecordIDResponse> CreateNewUser(RegisterUserCommandParameters parameters, CancellationToken cancellationToken)
        {
            var response = new RecordIDResponse();

            //authenticationService.CreatePasswordHash(parameters.Password, out byte[] passwordHash, out byte[] passwordSalt);

            ////Create new book
            //var newUser = new BookReviewer.Models.Users()
            //{
            //    Username = parameters.Username,
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt,
            //};

            //await this.context.AddAsync(newUser);
            //await this.context.SaveChangesAsync();

            //response.SetId(newUser.Id);
            return response;
        }
    }
}
