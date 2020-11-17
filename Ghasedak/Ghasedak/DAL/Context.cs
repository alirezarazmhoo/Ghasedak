using Ghasedak.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
           
        }
        public DbSet<BoxIncome> BoxIncomes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<AboutUs> AboutUss { get; set; }
        public DbSet<Stir> Stirs { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<DischargeRoute> DischargeRoutes { get; set; }
        public DbSet<Box> Boxs { get; set; }
        public DbSet<AndroidVersion> AndroidVersions { get; set; }
        public DbSet<Charity> Charitys { get; set; }
        public DbSet<Oprator> Oprators { get; set; }
        public DbSet<FinancialAid> FinancialAids { get; set; }
        public DbSet<FinancialServiceType> FinancialServiceTypes { get; set; }
        public DbSet<FlowerCrown> FlowerCrowns { get; set; }
        public DbSet<FlowerCrownType> FlowerCrownTypes { get; set; }
        public DbSet<Donator> Donators { get; set; }
        public DbSet<DeceasedName> DeceasedNames { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<SponsorPay> SponsorPays { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            modelBuilder.Entity<BoxIncome>()
            .HasOne(i => i.box)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
             modelBuilder.Entity<Box>()
            .HasOne(i => i.dischargeRoute)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

              
             
             
           
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
