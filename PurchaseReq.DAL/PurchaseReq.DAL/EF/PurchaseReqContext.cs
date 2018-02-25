using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PurchaseReq.Models.Entities;

namespace PurchaseReq.DAL.EF
{
    public class PurchaseReqContext : IdentityDbContext<IdentityUser>
    {
        private string connection = @"Server=(localdb)\mssqllocaldb;Database=PurchaseReq;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public PurchaseReqContext()
        {

        }

        public PurchaseReqContext(DbContextOptions options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch(Exception)
            {
                //Book says do something intelligent here
            }
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

            //Set up Alternative Request Base Request Foriegn key
            modelBuilder.Entity<AlternativeRequest>()
                .HasOne(r => r.Request)
                .WithMany(alt => alt.AlternativeRequests)
                .HasForeignKey(i => i.RequestId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //Set up Alternative Request Alternativve foreign key
            modelBuilder.Entity<AlternativeRequest>()
                .HasOne(alt => alt.Alternative)
                .WithMany(altr => altr.RequestAlternative)
                .HasForeignKey(i => i.AlternativeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //Sets up default value for Orders DateMade as today. 
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateMade)
                .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.EstimatedTotal)
                .HasComputedColumnSql("[QuantityRequested] * [EstimatedCost]");

                entity.Property(e => e.PaidTotal)
                .HasComputedColumnSql("[QuantityRequested] * [PaidCost]");
            });


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
        public DbSet<EmployeesBudgetCodes> EmployeesBudgetCodes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AlternativeRequest> AlternativeRequests { get; set; }

    }
}
