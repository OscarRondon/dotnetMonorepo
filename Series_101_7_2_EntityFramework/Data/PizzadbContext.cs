using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Series_101_7_2_EntityFramework.Models;

namespace Series_101_7_2_EntityFramework.Data;

public partial class PizzadbContext : DbContext
{
    public PizzadbContext()
    {
    }

    public PizzadbContext(DbContextOptions<PizzadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
