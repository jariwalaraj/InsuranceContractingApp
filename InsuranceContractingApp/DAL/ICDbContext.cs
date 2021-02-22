using InsuranceContractingAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceContractingAPI.DAL
{
    public class ICDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InsuranceContractingDb");
        }

        public DbSet<Advisors> Advisors { get; set; }

        public DbSet<Carriers> Carriers { get; set; }

        public DbSet<MGAs> MGAs { get; set; }

        public DbSet<Contractors> Contractors { get; set; }

        public DbSet<Contracts> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advisors>().HasKey(c => c.AdvisorsId);
            modelBuilder.Entity<Carriers>().HasKey(c => c.CarrierId);
            modelBuilder.Entity<MGAs>().HasKey(c => c.MGAId);
            modelBuilder.Entity<Contractors>().HasKey(c => c.ContractorId);
            modelBuilder.Entity<Contracts>().HasKey(c => c.ContractId);

            modelBuilder.Entity<Advisors>().Property(c => c.AdvisorsId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Carriers>().Property(c => c.CarrierId).ValueGeneratedOnAdd();
            modelBuilder.Entity<MGAs>().Property(c => c.MGAId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Contractors>().Property(c => c.ContractorId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Contracts>().Property(c => c.ContractId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Advisors>().Property(c => c.ContractorId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Carriers>().Property(c => c.ContractorId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<MGAs>().Property(c => c.ContractorId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        }

    }
}
