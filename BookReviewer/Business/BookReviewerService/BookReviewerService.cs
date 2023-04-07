using BookReviewer.IBusiness;
using BookReviewer.Localize;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace BookReviewer.Business.BookReviewerService
{
    public partial class BookReviewerService : IBookReviewerService
    {
        private readonly BookReviewerDbContext context;
        private readonly IStringLocalizer<Resource> localizer;

        public BookReviewerService(BookReviewerDbContext context, IStringLocalizer<Resource> localizer)
        {
            this.context = context;
            this.localizer = localizer;
        }

        public async void CheckUserPermissions(string username)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                throw new BaseException(localizer["BOOK_REVIEWER_SERVICE_USER_NOT_FOUND"]);
            }
        }
    }
}
