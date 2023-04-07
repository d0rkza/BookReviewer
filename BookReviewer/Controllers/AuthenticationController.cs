using Microsoft.AspNetCore.Mvc;
using BookReviewer.Models;
using BookReviewer.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Cors;

namespace BookReviewer.Controllers
{
    public class TokenResponse 
    {
        public string access_token = string.Empty;
        string token_type = "Bearer";
        public string expires_in = string.Empty;
    }
    [ApiController]
    [Route("{culture:culture}/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration configuration;

        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            this.configuration = configuration;
        }

        [HttpPost("MyLogin")]
        public IActionResult Login([FromBody] AuthenticateRequest user)
        {
            var userFromDummyData = DummnyData.DummyData._users.FirstOrDefault(x => x.Username == user.Username);
            if (user is null || userFromDummyData is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            else if (userFromDummyData.Password == user.Password)
            {
                var identity = new List<Claim>
                {
                    new Claim(ClaimTypes.UserData, userFromDummyData.Username),
                    new Claim(ClaimTypes.Role, userFromDummyData.Role),
                    new Claim(ClaimTypes.Name, userFromDummyData.FirstName)
                };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:Secret")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: configuration.GetValue<string>("JWT:ValidIssuer"),
                    audience: configuration.GetValue<string>("JWT:ValidAudience"),
                    claims: identity,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                var responseToken = new TokenResponse
                    {
                    access_token = tokenString,
                    expires_in = DateTime.Now.AddMinutes(60).ToString()
                };
                var jsonResponse = JsonConvert.SerializeObject(responseToken);
                return Ok(tokenString);
            }
            return Unauthorized();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}