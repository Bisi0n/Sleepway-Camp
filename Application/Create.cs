using Sleepway.Context;
using Sleepway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Create
    {
        public static void CreateCabin(CampsContext db)
        {
            Console.Write("Namnge stuga: ");
            var name = Console.ReadLine();

            var c = new Cabin
            {
                Name = name
            };
            db.Add(c);
            db.SaveChanges();
            Console.WriteLine("Stuga tillagd!");
        }
        public static void CreateCamper(CampsContext db)
        {
            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine();
            
            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("Check in: ");
            var checkIn = Console.ReadLine();
            DateTime startDate = Convert.ToDateTime(checkIn);

            Console.Write("Check out: ");
            var checkOut = Console.ReadLine();
            DateTime endDate= Convert.ToDateTime(checkOut);

            var c = new Camper
            {
                FirstName = firstName,
                LastName = lastName,
                StartDate = startDate,
                EndDate = endDate

            };
            db.Add(c);
            db.SaveChanges();
            Console.WriteLine("Gäst tillagd!");


        }
        public static void CreateCounselor(CampsContext db)
        {
            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("Titel: ");
            var nickName = Console.ReadLine();

            Console.Write("Check in: ");
            var checkIn = Console.ReadLine();
            DateTime startDate = Convert.ToDateTime(checkIn);

            Console.Write("Check out: ");
            var checkOut = Console.ReadLine();
            DateTime endDate = Convert.ToDateTime(checkOut);

            var c = new Counselor
            {
                FirstName = firstName,
                LastName = lastName,
                NickName = nickName,
                StartDate = startDate,
                EndDate = endDate

            };
            db.Add(c);
            db.SaveChanges();
            Console.WriteLine("Personal tillagt!");
        }
        public static void CreateNextOfKin(CampsContext db)
        {
            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("Relation: ");
            var relation = Console.ReadLine();


            var cam = db.Campers.ToList();

            foreach (var g in cam)
            {
                Console.WriteLine($"Gäst {g.CamperId} {g.FirstName} {g.LastName}");

            }

            Console.Write("Ange relaterad gäst ID: ");
            var iD = int.Parse(Console.ReadLine());

            var relatedCamper = db.Campers.FirstOrDefault(c => c.CamperId == iD);

            if (relatedCamper != null)
            {
                var c = new NextOfKin
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Relationship = relation,
                    CamperId= iD
                };
                db.Add(c);
                db.SaveChanges();
                Console.WriteLine("Släktning tillagd!");
            }
            else
            {
                Console.WriteLine("Relaterad gäst kunde ej hittas, Vänligen försök igen!");
            }

        }
    }
}
