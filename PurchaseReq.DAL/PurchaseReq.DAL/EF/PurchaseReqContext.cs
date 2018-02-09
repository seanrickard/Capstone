using System;
using System.Collections.Generic;
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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Approval> Approval { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}
