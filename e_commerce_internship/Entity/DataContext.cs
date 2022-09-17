using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace e_commerce_internship.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("dataConnection")
        {
            Database.SetInitializer(new DataInitilazier());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}