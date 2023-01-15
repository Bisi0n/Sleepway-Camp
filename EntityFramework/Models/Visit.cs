using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepway.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? CamperId { get; set; }
        public Camper Camper { get; set; }

        public int? NokId { get; set; }
        public ICollection<NextOfKin> NextOfKins { get; set; }

        public void ValidateVisit()
        {
            //To get total visit duration in hour
            var duration = (EndDate - StartDate).TotalHours;

            if (duration > 3)
            {
                throw new Exception("Besök får vara max 3 timmar!");
            }

            //Check if visit starts before 10 and ends after 8
            //StackOverFlow TimeOfDay/TimeSpan
            if (StartDate.TimeOfDay < new TimeSpan(10, 0, 0) || EndDate.TimeOfDay > new TimeSpan(20, 0, 0))
            {
                throw new Exception("Besök kan endast vara mellan klockan 10:00 till klockan 20:00");
            };
        }
    }
}
