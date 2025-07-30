using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL.Classes
{
    public class CollegeDBContext : DbContext
    {
        public CollegeDBContext(DbContextOptions<CollegeDBContext> options) :base(options){ }
        public CollegeDBContext() { }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Officer> Officer { get; set; }
        public DbSet<OrderManagement> OrderManagement { get; set; }
        public DbSet<SavingImages> SavingImages { get; set; }
        public DbSet<Statuse> Statuse { get; set; }

    }
}
