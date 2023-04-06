using BookReviewer.Entities;
using BookReviewer.Helpers;
using BookReviewer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookReviewer.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Role = "User", FirstName = "Test", LastName = "User", Username = "test", Password = "test" },
            new User { Id = 2, Role = "User", FirstName = "Test2", LastName = "User", Username = "test2", Password = "test" },
            new User { Id = 3, Role = "User", FirstName = "Test3", LastName = "User", Username = "test3", Password = "test" },
            new User { Id = 4, Role = "Admin", FirstName = "admin", LastName = "admin", Username = "admin", Password = "admin" }
        };

        //private readonly AppSettings _appSettings;
        private readonly IConfiguration configuration;

        //public UserService(IOptions<AppSettings> appSettings)
        public UserService(IConfiguration configuration)
        {
            //_appSettings = appSettings.Value;
            this.configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            var identity = new ClaimsIdentity();

            identity.AddClaim(new Claim(ClaimTypes.UserData, user.Username));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName + user.LastName));

            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            //get secret from appsettings
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JWT:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity, //new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
