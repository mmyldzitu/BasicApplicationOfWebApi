using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[] {
                new(){Id=1, Name="Bilgisayar", CreatedDate=DateTime.Now.AddDays(-3), Price=15000, Stock=300, CategoryId=1},
                new(){Id=2, Name="Televizyon", CreatedDate=DateTime.Now.AddDays(-2), Price=19000, Stock=50, CategoryId=1},
                new(){Id=3, Name="Klavye", CreatedDate=DateTime.Now.AddDays(-25), Price=900, Stock=500, CategoryId=1},

            });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {

                new(){Id=1, Name="Elektronik"},
                new(){Id=2, Name="Giyim"},


            }); 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
