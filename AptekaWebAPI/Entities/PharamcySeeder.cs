using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AptekaWebAPI.Entities
{
    public class PharamcySeeder
    {
        public string getHash(string password)
        {
            var hasher = MD5.Create();
            var bytes = Encoding.Default.GetBytes(password);
            return hasher.ComputeHash(bytes).ToString();
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Email = "test@mail.com",
                    IsAdmin = false,
                    PasswordHash = getHash("password")
                },
                new User()
                {
                    Id = 2,
                    Email = "test2@mail.com",
                    IsAdmin = false,
                    PasswordHash = getHash("password123")
                },
                new User()
                {
                    Id = 3,
                    Email = "test3@mail.com",
                    IsAdmin = false,
                    PasswordHash = getHash("internet")
                }
            };

            return users;
        }

    }
}
