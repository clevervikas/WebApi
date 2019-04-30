using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DAL
{
    public class StoreDataContext :DbContext
    {
        public StoreDataContext(DbContextOptions<StoreDataContext> options):base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
