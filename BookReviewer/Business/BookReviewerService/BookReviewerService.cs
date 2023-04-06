using BookReviewer.IBusiness;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookReviewer.Business.BookReviewerService
{
    public partial class BookReviewerService : IBookReviewerService
    {
        private readonly BookReviewerDbContext context;

        public BookReviewerService(BookReviewerDbContext context)
        {
            this.context = context;
        }

        public async void CheckUserPermissions(string username)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                throw new BaseException("User does not exists!");
            }

            //if (user.Role != 1 || user.Role != 2)
            //{
            //    throw new BaseException("You do not have permission to do that!");
            //}
        }
    }
}
