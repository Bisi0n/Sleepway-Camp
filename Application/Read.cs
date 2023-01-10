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

            foreach(var c in cab)
            {
                Console.WriteLine($"Stuga {c.CabinId} {c.Name}");

            }

        }
        public static void ReadDCamper(CampsContext db)
        {
            var cam = db.Campers.ToList();

            foreach (var c in cam)
            {
                Console.WriteLine($"Gäst {c.CamperId} {c.FirstName} {c.LastName}");

            }

        }
        public static void ReadDCounselor(CampsContext db)
        {
            var con = db.Counselors.ToList();

            foreach (var c in con)
            {
                Console.WriteLine($"Ledare {c.CounselorId} {c.FirstName} ''{c.NickName} '' {c.LastName}");

            }

        }
        public static void ReadDNextOfKin(CampsContext db)
        {
            var next = db.NextOfKins.ToList();

            foreach (var c in next)
            {
                Console.WriteLine($"Släkting {c.NokId} {c.FirstName} {c.LastName} är {c.Relationship} till gäst {c.Camper.CamperId}");

            }

        }
    }
}
