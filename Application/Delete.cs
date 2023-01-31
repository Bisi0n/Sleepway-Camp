using Sleepway.Context;
using Sleepway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Delete
    {
        public static void DeleteCabin(CampsContext db)
        {
           Read.ReadDCabin(db);
            
            Console.WriteLine();
            Console.Write("Ange ID: ");
            var cabinId = int.Parse(Console.ReadLine());

            var cabinDelete = db.Cabins.FirstOrDefault(c => c.CabinId == cabinId);

            if (cabinDelete != null)
            {
                var option = Utilities.ShowMenu("Är du säker på att du vill radera?", new[]
                {
                    "Ja",
                    "Nej"
                });
                Console.Clear();
                if(option == 0)
                {
                    db.Cabins.Remove(cabinDelete);
                    db.SaveChanges();
                    Console.WriteLine("Stugan är raderat!");
                }
                else
                {
                    Console.WriteLine("Borttagning avbröts");
                }
            }
            else
            {
                Console.WriteLine($"Stuga {cabinId} kunde ej hittas, vänligen försök igen!");
            }
        }
        public static void DeleteCamper(CampsContext db)
        {
            Read.ReadDCamper(db);
            Console.WriteLine();
            
            Console.Write("Ange ID: ");
            var camperId = int.Parse(Console.ReadLine());

            var camperDelete = db.Campers.FirstOrDefault(c => c.CamperId == camperId);

            

            if (camperDelete != null)
            {
                var option = Utilities.ShowMenu("Är du säker på att du vill radera?", new[]
                {
                    "Ja",
                    "Nej"
                });
                Console.Clear();
                if (option == 0)
                {
                    //Create history for deleted camper
                    var history = new History
                    {
                        FirstName = camperDelete.FirstName,
                        LastName = camperDelete.LastName,
                        Arrivals = camperDelete.StartDate,
                        Departure= camperDelete.EndDate,
                        Title = "Camper"
                    };
                    db.History.Add(history);
                    db.Campers.Remove(camperDelete);
                    db.SaveChanges();
                    Console.WriteLine("Gäst är raderat!");
                }
                else
                {
                    Console.WriteLine("Borttagning avbröts");
                }
            }
            else
            {
                Console.WriteLine($"Gäst {camperId} kunde ej hittas, vänligen försök igen!");
            }
        }
        public static void DeleteCounselor(CampsContext db)
        {
            Read.ReadDCounselor(db);
            Console.WriteLine();
            
            Console.Write("Ange ID: ");
            var counselorId = int.Parse(Console.ReadLine());

            var counselorDelete = db.Counselors.FirstOrDefault(c => c.CounselorId == counselorId);

            if (counselorDelete != null)
            {
                var option = Utilities.ShowMenu("Är du säker på att du vill radera?", new[]
                {
                    "Ja",
                    "Nej"
                });
                Console.Clear();
                if (option == 0)
                {
                    //Create history for deleted counselor
                    var history = new History
                    {
                        FirstName = counselorDelete.FirstName,
                        LastName = counselorDelete.LastName,
                        Arrivals = counselorDelete.StartDate,
                        Departure = counselorDelete.EndDate,
                        Title = "Counselor"
                    };
                    db.History.Add(history);

                    db.Counselors.Remove(counselorDelete);
                    db.SaveChanges();
                    Console.WriteLine("Ledare är raderat!");
                }
                else
                {
                    Console.WriteLine("Borttagning avbröts");
                }
            }
            else
            {
                Console.WriteLine($"Ledare {counselorId} kunde ej hittas, vänligen försök igen!");
            }
        }
        public static void DeleteNextOfKin(CampsContext db)
        {
            Read.ReadDNextOfKin(db)
            Console.WriteLine();

            Console.Write("Ange ID: ");
            var nokId = int.Parse(Console.ReadLine());

            var nokDelete = db.NextOfKins.FirstOrDefault(c => c.NokId == nokId);

            if (nokDelete != null)
            {
                var option = Utilities.ShowMenu("Är du säker på att du vill radera?", new[]
                {
                    "Ja",
                    "Nej"
                });
                Console.Clear();
                if (option == 0)
                {
                    db.NextOfKins.Remove(nokDelete);
                    db.SaveChanges();
                    Console.WriteLine("Släktning är raderat!");
                }
                else
                {
                    Console.WriteLine("Borttagning avbröts");
                }
            }
            else
            {
                Console.WriteLine($"Släktning {nokId} kunde ej hittas, vänligen försök igen!");
            }
        }
    }
}
