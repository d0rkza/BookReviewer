using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using System.ComponentModel.DataAnnotations;

namespace BookReviewer.Business.Users.Commands.LoginUserCommand
{
    public class LoginUserCommandParameters
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class LoginUserCommand : ESignRequest<LoginUserCommandParameters, RecordIDResponse>
    {
    }
}
