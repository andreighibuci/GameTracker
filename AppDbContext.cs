using GameTracker_release.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Game> Games { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ShoppingClass> ShoppingClass{ get; set; }
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<OrderDetail> OrderDetails { get; set; }
    }
    
}
