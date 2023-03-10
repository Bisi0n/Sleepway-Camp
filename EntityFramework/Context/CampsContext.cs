using Sleepway.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Globalization;

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

        public DbSet<Visit> Visits { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }

        public DbSet<History> History { get; set; }


        private readonly string connection = @"Server=DESKTOP-KVI14FD\SQLEXPRESS;Database=Sleepway;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=true;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabin>().HasData(
                   new Cabin
                   {
                       CabinId = 1,
                       Name = "High Hopes"
                   },
                   new Cabin
                   {
                       CabinId = 2,
                       Name = "Golden Valley"
                   },
                   new Cabin
                   {
                       CabinId = 3,
                       Name = "Moonlight Ridge"
                   }
               );
            modelBuilder.Entity<Camper>().HasData(
                new Camper { CamperId = 1, FirstName = "Brad", LastName = "Pitt" },
                new Camper { CamperId = 2, FirstName = "David", LastName = "Beckham", CabinId = 3, StartDate = new DateTime(2022, 7, 2), EndDate = new DateTime(2022, 7, 22) },
                new Camper { CamperId = 3, FirstName = "Sara", LastName = "Larsson" },
                new Camper { CamperId = 4, FirstName = "Eva", LastName = "Andersson" },
                new Camper { CamperId = 5, FirstName = "Johan", LastName = "Pär" },
                new Camper { CamperId = 6, FirstName = "Zlatan", LastName = "Ibrahimovid", CabinId = 1, StartDate = new DateTime(2022, 5, 2), EndDate = new DateTime(2022, 5, 15) },
                new Camper { CamperId = 7, FirstName = "Lisa", LastName = "Olsson" },
                new Camper { CamperId = 8, FirstName = "Martin", LastName = "Dalberg", CabinId = 3, StartDate = new DateTime(2022, 7, 5), EndDate = new DateTime(2022, 7, 12) },
                new Camper { CamperId = 9, FirstName = "Sandra", LastName = "Österberg" },
                new Camper { CamperId = 10, FirstName = "Annika", LastName = "Hermansson", CabinId = 3, StartDate = new DateTime(2022, 7, 23), EndDate = new DateTime(2022, 7, 28) },
                new Camper { CamperId = 11, FirstName = "Peter", LastName = "Parker", CabinId = 3, StartDate = new DateTime(2022, 7, 4), EndDate = new DateTime(2022, 7, 16) },
                new Camper { CamperId = 12, FirstName = "Thierry", LastName = "Henry", CabinId = 1, StartDate = new DateTime(2022, 5, 2), EndDate = new DateTime(2022, 5, 15) },
                new Camper { CamperId = 13, FirstName = "Lionel", LastName = "Messi", CabinId = 2, StartDate = new DateTime(2022, 6, 3), EndDate = new DateTime(2022, 6, 11) },
                new Camper { CamperId = 14, FirstName = "Koby", LastName = "Bryant", CabinId = 1, StartDate = new DateTime(2022, 5, 2), EndDate = new DateTime(2022, 5, 15) },
                new Camper { CamperId = 15, FirstName = "Muhammed", LastName = "Ali", CabinId = 1, StartDate = new DateTime(2022, 5, 2), EndDate = new DateTime(2022, 5, 15) },
                new Camper { CamperId = 16, FirstName = "Pele", LastName = "Nasicmo", CabinId = 2, StartDate = new DateTime(2022, 6, 8), EndDate = new DateTime(2022, 6, 21) },
                new Camper { CamperId = 17, FirstName = "Ronaldo", LastName = "Nazario", CabinId = 2, StartDate = new DateTime(2022, 6, 12), EndDate = new DateTime(2022, 6, 14) },
                new Camper { CamperId = 18, FirstName = "Ronaldinho", LastName = "Gaucho", CabinId = 2, StartDate = new DateTime(2022, 6, 2), EndDate = new DateTime(2022, 6, 10) }
                );

            //This to ensure that visit starts from 10 and not before
            modelBuilder.Entity<Visit>()
                .Property(v => v.StartDate)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("'10:00:00'");

            modelBuilder.Entity<Visit>()
                .Property(v => v.EndDate)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("'20:00:00'");
            //.HasDbCheckConstraint("CK_Visit_Duration", "DATEDIFF(hour, StartDate, EndDate) <= 3"); Error

            //https://learn.microsoft.com/sv-se/ef/core/modeling/indexes?tabs=data-annotations#check-constraints
            
            modelBuilder.Entity<Visit>()
                .ToTable(v => v.HasCheckConstraint("CK_Visit_Duration", "DATEDIFF(hour, StartDate, EndDate) <= 3"));


            //The dependent side could not be determined for the one-to-one relationship between 'Camper.Visits' and 'Visit.Camper'
            modelBuilder.Entity<Visit>()
                .HasOne(v => v.Camper)
                .WithOne(c => c.Visits)
                .HasForeignKey<Visit>(v => v.CamperId)
    .           IsRequired(false);





            modelBuilder.Entity<Counselor>().HasData(
                new Counselor { CounselorId = 1, FirstName = "Abdi", LastName = "Mohamed", NickName = "Chefen", CabinId = 1, StartDate = new DateTime(2022, 5, 1), EndDate = new DateTime(2022, 5, 29) },
                new Counselor { CounselorId = 2, FirstName = "Mohammed", LastName = "Jafari", NickName = "Bossen", CabinId = 2, StartDate = new DateTime(2022, 6, 1), EndDate = new DateTime(2022, 6, 29) },
                new Counselor { CounselorId = 3, FirstName = "Peter", LastName = "Nilsson", NickName = "Professorn", CabinId = 3, StartDate = new DateTime(2022, 7, 1), EndDate = new DateTime(2022, 7, 29) },
                new Counselor { CounselorId = 4, FirstName = "Mirella", LastName = "Mårtensson", NickName = "Nybörjare" }
                );
            modelBuilder.Entity<NextOfKin>().HasData(
                new NextOfKin { NokId = 1, FirstName = "Gunnila", LastName = "Strömmer", Relationship = "Faster", CamperId = 8 },
                new NextOfKin { NokId = 2, FirstName = "Herman", LastName = "Hermansson", Relationship = "Far", CamperId = 10 },
                new NextOfKin { NokId = 3, FirstName = "Antonella", LastName = "Roccuzzo", Relationship = "Fru", CamperId = 13 }
                );
            modelBuilder.Entity<Visit>().HasData(
                 new Visit { VisitId = 1, CamperId = 8, NokId = 1, StartDate = new DateTime(2022, 7, 8, 10, 0, 0), EndDate = new DateTime(2022, 7, 8, 13, 0, 0) },
                 new Visit { VisitId = 2, CamperId = 10, NokId = 2, StartDate = new DateTime(2022, 7, 25, 14, 0, 0), EndDate = new DateTime(2022, 7, 25, 14, 30, 0) },
                 new Visit { VisitId = 3, CamperId = 13, NokId = 3, StartDate = new DateTime(2022, 6, 5, 19, 0, 0), EndDate = new DateTime(2022, 6, 5, 19, 59, 0) }
                 );


        }
    }
}
