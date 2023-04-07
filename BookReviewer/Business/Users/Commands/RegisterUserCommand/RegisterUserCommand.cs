using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using System.ComponentModel.DataAnnotations;

namespace BookReviewer.Business.Users.Commands.RegisterUserCommand
{
    public class RegisterUserCommandParameters
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class RegisterUserCommand : ESignRequest<RegisterUserCommandParameters, RecordIDResponse>
    {
    }
}

