using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneBatSignal.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public int CohortId { get; set; }

        public  Cohort Cohort { get; set; }

        
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        
        public bool IsInstructor { get; set; }


    }
}
