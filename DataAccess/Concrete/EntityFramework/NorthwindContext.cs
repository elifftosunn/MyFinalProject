using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : db tabloları ile proje class'larını bağlamak
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //hangi db ile ilişkili olduğunu belirteceğimiz yer
        {
            // Trusted_Connection=true => Kullanıcı adı, şifre gerektirmiyor demek
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product>  Products { get; set; } // Benim yazmış olduğum Product'ım db'deki Products'a bağlı diyorum
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
