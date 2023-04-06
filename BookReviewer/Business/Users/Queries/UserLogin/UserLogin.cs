using BookReviewer.Business.Authors.Queries.GetAuthorsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.Business.Users.Queries.UserLogin
{
    public class UserLogin : IRequest<UserLoginDTO>
    {
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string AuthorSurname { get; set; }
    }
}
