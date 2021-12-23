using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSharpAssignment2.Models
{
    public class MyDatabaseContext:DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        { 

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<ProductCartViewModel> ProductCartViewModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { statusId = 201, status = "Ordered"},
                new Status { statusId = 202, status = "Cancelled" },
                new Status { statusId = 203, status = "Completed" }
                );
        }
        

        
    }
}
