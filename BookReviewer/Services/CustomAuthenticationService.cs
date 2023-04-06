using BookReviewer.IBusiness;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookReviewer.Business
{
    public class CustomAuthenticationService : ICustomAuthenticationService
    {
    }
}
