using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalsCompany.Models.Career;

namespace PharmaceuticalsCompany.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EducationDetails> EducationDetails { get; set; }
        public DbSet<ApplicationUser> Careers { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EducationDetails>()
            .HasOne<ApplicationUser>(e=>e.User)
            .WithMany(u => u.educationDetails)
            .HasForeignKey(s => s.User_id);

        }
    }
}
