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
                //Checks if cabin is missing counselor
                else if (searchCabin.Counselor == null)
                {
                    Console.WriteLine("⚠ Stuga saknar personal!");
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
            Console.WriteLine("Arbete pågår");

            //var cab = db.Cabins.ToList();

            //foreach (var c in cab)
            //{
            //    Console.WriteLine($"Stuga {c.CabinId} {c.Name}");

            //}
            //Console.WriteLine();

            //Console.Write("Ange stuga ID: ");
            //int cabinId = int.Parse(Console.ReadLine());

            //var searchCabin = db.Cabins.FirstOrDefault(c => c.CabinId == cabinId);

            //if (searchCabin != null)
            //{
            //    Console.WriteLine($"Stuga {searchCabin.CabinId} {searchCabin.Name}");
            //    Console.WriteLine();

            //    //.Any() return campers with next of kin
            //    var campersWithNOK = db.Campers.Where(c => c.CabinId == cabinId && c.NextOfKins.Any()).ToList();
            //    if (campersWithNOK.Count > 0)
            //    {
            //        Console.WriteLine("Gäster med släktningar:");
            //        foreach (var c in campersWithNOK)
            //        {
            //            Console.WriteLine($" {c.CamperId} {c.FirstName} {c.LastName} släkting: ");

            //            //System.NullReferenceException
            //            if (c.NextOfKins != null)
            //            {
            //                //print out NextOfKin
            //                foreach (var nok in c.NextOfKins)
            //                {
            //                    Console.WriteLine($"{nok.FirstName} {nok.LastName}");
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Gäster med släktningar saknas!");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Inga gäster med släktningar bor i denna stuga.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Stuga kunde ej hittas, vänligen försök igen!");
            //}

        }
    }
}
