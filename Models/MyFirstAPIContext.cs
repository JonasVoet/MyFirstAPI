using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Models
{
    public class MyFirstAPIContext : DbContext
    {
        public MyFirstAPIContext(DbContextOptions<MyFirstAPIContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                               .HasOne(c => c.Category) // c = category
                               .WithMany(p => p.Products) // p = product
                               .HasForeignKey(k => k.CategoryId); // k = key
        }



    }
}
