using Sleepway.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Read
    {
        public static void ReadDCabin(CampsContext db)
        {
            var cab = db.Cabins.ToList();
            Console.WriteLine("Stugor: ");
            
            foreach(var c in cab)
            {
                Console.WriteLine($"{c.CabinId} {c.Name}");

            }

        }
        public static void ReadDCamper(CampsContext db)
        {
            var cam = db.Campers.ToList();
            Console.WriteLine("Gäster: ");
            
            foreach (var c in cam)
            {
                Console.WriteLine($"{c.CamperId} {c.FirstName} {c.LastName}");

            }

        }
        public static void ReadDCounselor(CampsContext db)
        {
            var con = db.Counselors.ToList();
            Console.WriteLine("Ledare");

            foreach (var c in con)
            {
                Console.WriteLine($"{c.CounselorId} {c.FirstName} ''{c.NickName} '' {c.LastName}");

            }

        }
        public static void ReadDNextOfKin(CampsContext db)
        {
            var next = db.NextOfKins.ToList();
            Console.WriteLine("Släktnigar: ");

            foreach (var c in next)
            {
                Console.WriteLine($"Släkting {c.NokId} {c.FirstName} {c.LastName} är {c.Relationship} till gäst {c.Camper.CamperId}");

            }

        }
    }
}
