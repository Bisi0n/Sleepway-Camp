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

        public int CamperId { get; set; }
        public Camper Camper { get; set; }

        public int NokId { get; set; }
        public ICollection<NextOfKin> NextOfKins { get; set; }
    }
}
