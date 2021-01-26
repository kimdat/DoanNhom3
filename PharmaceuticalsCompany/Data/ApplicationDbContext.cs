using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalsCompany.Models;
using PharmaceuticalsCompany.Models.Career;
using PharmaceuticalsCompany.Models.Products;
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
        public DbSet<ProductCapsule> ProductCapsules { get; set; }
        public DbSet<ProductLiquidFilling> ProductLiquidFillings { get; set; }
        public DbSet<ProductTablet> ProductTablets { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<QuoteUs> QuoteUs { get; set; }
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
