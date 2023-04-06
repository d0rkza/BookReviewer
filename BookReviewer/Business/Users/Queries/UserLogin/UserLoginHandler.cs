using BookReviewer.Business.Authors.Queries.GetAuthorsQuery;
using BookReviewer.Models;
using BookReviewer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Users.Queries.UserLogin
{
    internal class UserLoginHandler : IRequestHandler<UserLogin, UserLoginDTO>
    {
        private readonly BookReviewerDbContext context;

        public UserLoginHandler(BookReviewerDbContext context)
        {
            this.context = context;
        }

        public Task<UserLoginDTO> Handle(UserLogin request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<UserLoginDTO> Handle(UserLogin request, CancellationToken cancellationToken)
        //{
        //    //var requestedUser = await this.context.User.FirstOrDefaultAsync(x => x.Username => request.)



        //    return UnauthorizedAccessException();
        //}
    }
}
