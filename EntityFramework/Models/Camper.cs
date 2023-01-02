using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepway.Models
{
    public class Camper
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Room { get; set; }

        public virtual Cabin Cabin { get; set; }
        public virtual ICollection<NextOfKin> NextOfKins { get; set; }

    }
}
