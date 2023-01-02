using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //[Required]
        //public Camper Id { get; set; }
        

        public Camper CamperCamper { get; set; }

    }
}
