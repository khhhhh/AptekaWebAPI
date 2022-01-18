using AptekaWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Database
{
    public class PharacyContext : DbContext
    {
        public PharacyContext(DbContextOptions<PharacyContext> options) : base(options)
        { }
        public DbSet<Cart> MyProperty { get; set; }
        public DbSet<Product> MyProperty { get; set; }
        public DbSet<ProductCategory> MyProperty { get; set; }
    }
}
