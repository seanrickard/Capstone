using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurchaseReq.Models.Entities;
using System;

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
        public DbSet<BudgetCode> BudgetCodes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<EmployeesBudgetCodes> EmployeesBudgetCodes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Campus> Campuses{ get; set; }
        public DbSet<BudgetAmount> BudgetAmounts { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
