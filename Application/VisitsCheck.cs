using Microsoft.EntityFrameworkCore;
using Sleepway.Context;
using Sleepway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class VisitsCheck
    {
        public static void AddVisit(CampsContext db)
        {
            var cam = db.Campers.ToList();
            Console.WriteLine("Gäster: ");

            foreach (var c in cam)
            {
                Console.WriteLine($"{c.CamperId} {c.FirstName} {c.LastName}");

            }
            Console.WriteLine();

            Console.Write("Ange relaterad gäst ID: ");
            var iD = int.Parse(Console.ReadLine());

            Console.Write("Ankomst: ");
            var checkIn = Console.ReadLine();
            DateTime startDate = Convert.ToDateTime(checkIn);

            Console.Write("Avgång : ");
            var checkOut = Console.ReadLine();
            DateTime endDate = Convert.ToDateTime(checkOut);

            var relatedCamper = db.Campers.FirstOrDefault(c => c.CamperId == iD);
            
            //Check related camper first
            if (relatedCamper != null)
            {
                var newVisitor = new Visit
                {
                    CamperId = iD,
                    StartDate = startDate,
                    EndDate = endDate
                };
                
                //Validate visit
                newVisitor.ValidateVisit();
                db.Add(newVisitor);
                db.SaveChanges();

                Console.WriteLine("Besök bokad!");

            }
            else
            {
                Console.WriteLine("Relaterad gäst kunde ej hittas, Vänligen försök igen!");
            }



        }
        public static void DisplayVisit (CampsContext db)
        {
            //https://stackoverflow.com/questions/67534732/entity-framework-join-two-tables-and-where-clause
            //https://learn.microsoft.com/en-us/ef/core/querying/complex-query-operators

            var visitInfo = from visit in db.Visits
                            join camper in db.Campers on visit.CamperId equals camper.CamperId

                            join counselor in db.Counselors on camper.CabinId equals counselor.CabinId
                            
                            select new {Cabin = camper.Cabin, Counselor = counselor };

            foreach (var visit in visitInfo)
            {
                Console.WriteLine("Du ska besöka: ");
                Console.WriteLine($"Stuga: {visit.Cabin} ");

                Console.WriteLine("Du ska kontakta: ");
                Console.WriteLine($"Ledare: {visit.Counselor}");
            }



        }
    }
}
