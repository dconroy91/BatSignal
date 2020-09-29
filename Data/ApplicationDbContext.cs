using System;
using System.Collections.Generic;
using System.Text;
using CapstoneBatSignal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CapstoneBatSignal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //add DB sets (Banagazon restaurant tracker)
        //if firat migration doesnt work, remove-migration. Run one again after fixing 
        public DbSet<Cohort> Cohort { get; set; }
        public DbSet<Requests> Requests { get; set; }

        public DbSet<ApplicationUser> User { get; set; }

        



    }
}
