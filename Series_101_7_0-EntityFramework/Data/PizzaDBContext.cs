using Microsoft.EntityFrameworkCore;
using Series_101_7_0_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_101_7_0_EntityFramework.Data
{
    public class PizzaDBContext: DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ISC\SQLEXPRESS;Initial Catalog=PIZZADB;User ID=vscode;Password=vscode123; TrustServerCertificate=True");
        }
    }
}
