using System.Text.Json.Serialization;

namespace BookReviewer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
    //TODO: Implement user to be stored in database
    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Username { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Role { get; set; }
    //    public string Password { get; set; }

    //    [JsonIgnore]
    //    public string PasswordHash { get; set; }
    //    [JsonIgnore]
    //    public string PasswordSalt { get; set; }
    //    public string Token { get; set; }
    //    public DateTime TokenCreated { get; set; }
    //    public DateTime TokenExpires { get; set; }
    //}
}
