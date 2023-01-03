using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepway.Models
{
    public class Cabin
    {
        [Key]
        public int CabinId { get; set; }
        public string Name { get; set; }


        //fk

        public virtual ICollection<Counselor> Counselors { get; set; }
        public virtual ICollection<Camper> Campers { get; set; }

        public virtual Counselor Counselor { get; set; }
    }
}
