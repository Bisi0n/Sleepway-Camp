using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepway.Models
{
    public class History
    {
        public int HistoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime Arrivals { get; set; }
        public DateTime Departure { get; set; }
    }
}
