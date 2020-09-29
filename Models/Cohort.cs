using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneBatSignal.Models
{
    public class Cohort
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
