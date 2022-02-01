using AptekaWebAPI.Database;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AptekaWebAPI.Entities
{
    public class PharamcySeeder
    {
        private readonly PharmacyContext pharmacyDB;
        private List<ProductCategory> productCategories;
        private List<Product> products;
        private List<Address> addresses;
        private List<User> users;
        public PharamcySeeder(PharmacyContext pharmacyDB)
        {
            this.pharmacyDB = pharmacyDB;
        }
        public string getHash(string password)
        {
            var hasher = MD5.Create();
            var bytes = Encoding.ASCII.GetBytes(password);
            var hash = hasher.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        private IEnumerable<ProductCategory> GetProductCategories()
        {
            productCategories = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Name = "Analgesic"
                },
                new ProductCategory()
                {
                    Name = "Antipyretics"
                },
                new ProductCategory()
                {
                    Name = "Antihistamines"
                },
            };
            return productCategories; 
        }

        private IEnumerable<Product> GetProducts()
        {
            products = new List<Product>()
            {
                new Product()
                {
                    Name = "Aspirin",
                    Categories = new List<ProductCategory> { productCategories[0], productCategories[1] },
                    Price = 10,
                    Count = 100,
                    Description = "Perfect against your headache!"
                },
                new Product()
                {
                    Name = "Chlorphenamine",
                    Categories = new List<ProductCategory> { productCategories[0], productCategories[1] },
                    Price = 15,
                    Count = 200,
                    Description = "Helps you stop sneezing!"
                }
            };

            return products;
        }
        private IEnumerable<Address> GetAddresses()
        {
            addresses = new List<Address>()
            {
                new Address()
                {
                    City = "Lublin",
                    Street = "ul. Langiewicza, 5",
                    PostalCode = "20-035",
                },
                new Address()
                {
                    City = "Warszawa",
                    Street = "al. Jana Pawła II, 10",
                    PostalCode = "00-123",
                },
                new Address()
                {
                    City = "Bydgoszcz",
                    Street = "ul. Księdza Hugona Kołłątaja, 5",
                    PostalCode = "85-008",
                },
            };
            return addresses;
        }
        private IEnumerable<User> GetUsers()
        {
            users = new List<User>()
            {
                new User()
                {
                    Email = "dimon1432b@gmail.com",
                    IsAdmin = true,
                    PasswordHash = getHash("password"),
                    Address = addresses[1],
                    Name = "Dzmitry",
                },
                new User()
                {
                    Email = "oleg_hutsko@mail.ru",
                    IsAdmin = true,
                    PasswordHash = getHash("password123"),
                    Address = addresses[0],
                    Name = "Aleh",
                },
                new User()
                {
                    Email = "taras.iskiv@gmail.com",
                    IsAdmin = true,
                    PasswordHash = getHash("internet"),
                    Address = addresses[2],
                    Name = "Taras",
                }
            };

            return users;
        }

        public void Seed()
        {
            if (pharmacyDB.Database.CanConnect())
            {
                if (!pharmacyDB.Users.Any())
                {
                    var addresses = GetAddresses(); 
                    var users = GetUsers();
                    var productCategories = GetProductCategories();
                    var products = GetProducts();

                    pharmacyDB.Addresses.AddRange(addresses);
                    pharmacyDB.ProductCategories.AddRange(productCategories);
                    pharmacyDB.Users.AddRange(users);
                    pharmacyDB.Products.AddRange(products);
                    
                    pharmacyDB.SaveChanges();
                }

            }
        }

    }
}
