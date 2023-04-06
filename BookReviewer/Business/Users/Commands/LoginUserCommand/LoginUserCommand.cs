using BookReviewer.Business.Users.Commands.RegisterUserCommand;
using BookReviewer.Models.Request;
using BookReviewer.Models.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
