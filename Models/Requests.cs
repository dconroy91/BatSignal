using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneBatSignal.Models
{
    public class Requests
    {
        public int Id { get; set; }
        public string StudentUserId { get; set; }

        public ApplicationUser StudentUser { get; set; }

        public string InstructorUserId { get; set; }

        public ApplicationUser InstructorUser { get; set; }
        
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateFinished { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsTutoring { get; set; }
    }
}
