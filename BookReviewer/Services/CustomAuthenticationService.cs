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
        //private readonly BookReviewerDbContext context;
        //private readonly IConfiguration configuration;

        //public CustomAuthenticationService(BookReviewerDbContext context, IConfiguration configuration)
        //{
        //    this.context = context;
        //    this.configuration = configuration;
        //}

        //public async void CheckUserPermissions(string username)
        //{
        //    var user = await this.context.Users.FirstOrDefaultAsync(x => x.Username == username);

        //    if (user == null)
        //    {
        //        throw new BaseException("User does not exists!");
        //    }

        //    //if (user.Role != 1 || user.Role != 2)
        //    //{
        //    //    throw new BaseException("You do not have permission to do that!");
        //    //}
        //}
        //public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        //public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512(passwordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        return computedHash.SequenceEqual(passwordHash);
        //    }
        //}

        //string ICustomAuthenticationService.CreateToken(BookReviewer.Models.Users user)
        //{
        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Username),
        //        new Claim(ClaimTypes.Role, "Admin")
        //    };

        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
        //        configuration.GetSection("AppSettings:Token").Value));

        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var token = new JwtSecurityToken(
        //        claims: claims,
        //        expires: DateTime.Now.AddDays(1),
        //        signingCredentials: creds);

        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwt;
        //}

        //Business.RefreshToken ICustomAuthenticationService.GenerateRefreshToken()
        //{
        //    var refreshToken = new Business.RefreshToken
        //    {
        //        Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
        //        Expires = DateTime.Now.AddDays(7),
        //        Created = DateTime.Now
        //    };

        //    return refreshToken;
        //}

        //public void SetRefreshToken(Business.RefreshToken newRefreshToken)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = newRefreshToken.Expires
        //    };
        //    //await Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

        //    //user.RefreshToken = newRefreshToken.Token;
        //    //user.TokenCreated = newRefreshToken.Created;
        //    //user.TokenExpires = newRefreshToken.Expires;
        //}

        //public class RefreshToken
        //{
        //    public string Token { get; set; } = string.Empty;
        //    public DateTime Created { get; set; } = DateTime.Now;
        //    public DateTime Expires { get; set; }
        //}

        //public JwtSecurityToken GetToken(List<Claim> claims)
        //{
        //    var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

        //    var token = new JwtSecurityToken(
        //        issuer: configuration["JWT:ValidIssuer"],
        //        audience: configuration["JWT:ValidAudience"],
        //        expires: DateTime.Now.AddHours(24),
        //        claims: claims,
        //        signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
        //        );
        //    return token;
        //}
    }
}
