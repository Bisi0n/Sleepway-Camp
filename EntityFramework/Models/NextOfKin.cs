using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepway.Models
{
    public class NextOfKin
    {
        [Key]
        public int NokId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }

        //Must have a camper relative
        [Required]
        public int CamperId { get; set; }
        public Camper Camper { get; set; }
        
        public int? VisitId { get; set; }
        public virtual Visit Visit { get; set; }


    }
}
