using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepway.Models
{
    public class Counselor
    {
        [Key]
        public int CounselorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        //[ForeignKey("Cabin")]
        public int? CabinId { get; set; }
        
        public virtual Cabin Cabin { get; set; }
    }
}
