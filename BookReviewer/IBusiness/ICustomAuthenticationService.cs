using BookReviewer.Business;
using BookReviewer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookReviewer.IBusiness
{
    public interface ICustomAuthenticationService
    {
        //TODO: Implement authentication with real users
        //void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        //bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        //RefreshToken GenerateRefreshToken();

        //void SetRefreshToken(RefreshToken newRefreshToken);

        //string CreateToken(Models.Users user);

        //public JwtSecurityToken GetToken(List<Claim> claims);
    }
}
