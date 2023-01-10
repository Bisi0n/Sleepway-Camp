using Sleepway.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepway.Context
{
    public class CampsContext : DbContext
    {
        public CampsContext() 
        {
            
        }

        public CampsContext(DbContextOptions<CampsContext> options)
            : base(options)
        {

        }

        //public DbSet<Booking> Bookings { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }

        private readonly string connection = @"Server=DESKTOP-GHKGJ8K\SQLEXPRESS;Database=Sleepway;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=true;"; 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
