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
                    Email = "dimon1432b@gmail.com",
                    IsAdmin = true,
                    PasswordHash = getHash("password")
                },
                new User()
                {
                    Id = 2,
                    Email = "oleg_hutsko@mail.ru",
                    IsAdmin = true,
                    PasswordHash = getHash("password123")
                },
                new User()
                {
                    Id = 3,
                    Email = "taras.iskiv@gmail.com",
                    IsAdmin = true,
                    PasswordHash = getHash("internet")
                }
            };

            return users;
        }

    }
}
