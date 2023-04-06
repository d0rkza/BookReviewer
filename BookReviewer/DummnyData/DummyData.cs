using BookReviewer.Entities;

namespace BookReviewer.DummnyData
{
    static public class DummyData
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        public static List<User> _users = new List<User>
            {
                new User { Id = 1, Role = "User", FirstName = "Test", LastName = "User", Username = "test", Password = "test" },
                new User { Id = 2, Role = "User", FirstName = "Test2", LastName = "User", Username = "test2", Password = "test" },
                new User { Id = 3, Role = "User", FirstName = "Test3", LastName = "User", Username = "test3", Password = "test" },
                new User { Id = 4, Role = "Admin", FirstName = "admin", LastName = "admin", Username = "admin", Password = "admin" }
            };
    }
}
