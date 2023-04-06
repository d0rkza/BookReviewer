using BookReviewer.IBusiness;
using BookReviewer.Models;
using BookReviewer.Models.Exceptions;
using BookReviewer.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookReviewer.Business.Users.Commands.LoginUserCommand
{
    public class LoginUserCommandHandler { }
    //public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, RecordIDResponse>
    //{
    //    private readonly BookReviewerDbContext context;
    //    private readonly IBookReviewerService service;
    //    private readonly ICustomAuthenticationService authService;

    //    public LoginUserCommandHandler(BookReviewerDbContext context, IBookReviewerService service, ICustomAuthenticationService authService)
    //    {
    //        this.context = context;
    //        this.service = service;
    //        this.authService = authService;
    //    }



        //public async Task<JwtSecurityToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        //{
        //    //return await this.LoginUser(request.Data, cancellationToken);
        //    var response = new RecordIDResponse();

        //    var user = await this.context.Users.FirstOrDefaultAsync(x => x.Username == request.Data.Username);

        //    if (!authService.VerifyPasswordHash(request.Data.Password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        throw new BaseException("Username and password are not correct");
        //    }

        //    var authClaims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Username),
        //        new Claim("role", user.Role)
        //    };

        //    var t = authService.GetToken(authClaims);

        //    //var token = authService.CreateToken(
        //    //    new Models.Models.Users
        //    //    {
        //    //        Username = user.Username,
        //    //        PasswordHash = user.PasswordHash,
        //    //        PasswordSalt = user.PasswordSalt,
        //    //    });

        //    user.RefreshToken = t.ToString();

        //    await this.context.SaveChangesAsync();

        //    return t;
        //}

        //public async Task<JwtSecurityToken> LoginUser(LoginUserCommandParameters parameters, CancellationToken cancellationToken)
        //{
        //    var response = new RecordIDResponse();

        //    var user = await this.context.Users.FirstOrDefaultAsync(x => x.Username == parameters.Username);

        //    if(!authService.VerifyPasswordHash(parameters.Password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        throw new BaseException("Username and password are not correct");
        //    }

        //    var authClaims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Username),
        //        //new Claim("role", user.Role) add role column to db
        //    };

        //    var t = authService.GetToken(authClaims);

        //    var token = authService.CreateToken(
        //        new Models.Users
        //        {
        //            Username = user.Username,
        //            PasswordHash = user.PasswordHash,
        //            PasswordSalt = user.PasswordSalt,
        //        });

        //    user.RefreshToken = t.ToString();

        //    await this.context.SaveChangesAsync();

        //    response.SetId(user.Id);
        //    response.AddMessage(new Models.IResponse.Message { Text = token.ToString() });
        //    return t;
        //}

        //Task<RecordIDResponse> IRequestHandler<LoginUserCommand, RecordIDResponse>.Handle(LoginUserCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    //}
}
