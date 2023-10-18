using Complex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Data
{
    public class PortalContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Material> Materials { get; set; } = null!;

        public DbSet<Skill> Skills { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Complex;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
