using Sleepway.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Report
    {
        public static void SearchCamper(CampsContext db)
        {
            var cab = db.Cabins.ToList();

            foreach (var c in cab)
            {
                Console.WriteLine($"Stuga {c.CabinId} {c.Name}");

            }
            Console.WriteLine();
            
            Console.Write("Ange stuga ID: ");
            var cabinId = int.Parse(Console.ReadLine());

            var searchCabin = db.Cabins.FirstOrDefault(c => c.CabinId == cabinId);

            Console.WriteLine();
            if(searchCabin != null )
            {
                Console.WriteLine($"Stuga {searchCabin.CabinId} {searchCabin.Name}");
                Console.WriteLine();
                
                var camper = db.Campers.Where(c => c.CabinId == cabinId).ToList();
                if (camper.Count > 0)
                {
                    Console.WriteLine("Gäster:");
                    foreach (var c in camper)
                    {
                        Console.WriteLine($" {c.CamperId} {c.FirstName} {c.LastName}");
                    }
                }
                else
                {
                    Console.WriteLine("Inga gäster bor i denna stuga.");
                }
            }
            else
            {
                Console.WriteLine("Stuga kunde ej hittas, vänligen försök igen!");
            }            
        }
        public static void SearchNOK(CampsContext db)
        {
            var cab = db.Cabins.ToList();

            foreach (var c in cab)
            {
                Console.WriteLine($"Stuga {c.CabinId} {c.Name}");

            }
            Console.WriteLine();

            Console.Write("Ange stuga ID: ");
            var cabinId = int.Parse(Console.ReadLine());

            var searchCabin = db.Cabins.FirstOrDefault(c => c.CabinId == cabinId);

            Console.WriteLine();
            if (searchCabin != null)
            {
                Console.WriteLine($"Stuga {searchCabin.CabinId} {searchCabin.Name}");
                Console.WriteLine();

                var camper = db.Campers.Where(c => c.CabinId == cabinId && c.NextOfKins != null).ToList();
                if (camper.Count > 0)
                {
                    Console.WriteLine("Gäster med släktningar:");
                    foreach (var c in camper)
                    {
                        Console.WriteLine($" {c.CamperId} {c.FirstName} {c.LastName} släkting {c.NextOfKins}");
                    }
                }
                else
                {
                    Console.WriteLine("Inga gäster bor i denna stuga.");
                }
            }
            else
            {
                Console.WriteLine("Stuga kunde ej hittas, vänligen försök igen!");
            }
        }
    }
}
