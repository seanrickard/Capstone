using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.DAL.EF
{
    public class PurchaseReqContext : DbContext
    {
        private string connection = @"Server=(localdb)\mssqllocaldb;Database=PurchaseReq;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public PurchaseReqContext()
        {

        }

        public PurchaseReqContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection, options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Sets up CFO Composite Key
            modelBuilder.Entity<CFO>().HasKey(t => new { t.Id, t.EmployeeId, t.DateAdded });

            //Sets up Index for CFO ID
            modelBuilder
                .Entity<CFO>()
                .HasIndex(I => I.Id);

            //Sets up CFO Relationship
            modelBuilder.Entity<CFO>().HasMany(c => c.CFOApprovals)
                .WithOne(a => a.CFO).HasForeignKey(a => a.CFOId).HasPrincipalKey(c => c.Id);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Approval> Approval { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<SupervisorApproval> SupervisorApprovals { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CFO> CFOs { get; set; }
        public DbSet<CFOApproval> CFOApprovals { get; set; }
        public DbSet<BudgetCode> BudgetCodes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }

    }
}
