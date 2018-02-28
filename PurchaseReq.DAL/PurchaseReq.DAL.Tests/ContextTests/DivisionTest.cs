using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PurchaseReq.DAL.Tests.ContextTests
{
    [Collection("PurchaseReq.DAL")]
    public class DivisionTest : IDisposable
    {
        private readonly PurchaseReqContext _db;

        private DbInitializer dbInitializer;

        public DivisionTest()
        {
            _db = new PurchaseReqContext();
            dbInitializer = new DbInitializer(_db);
            dbInitializer.SeedData();
        }

        public void Dispose()
        {
            CleanDatabase();
            _db.Dispose();
        }

        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Delete from [User].[Divisions]");
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[User].[Divisions]\" , RESEED, -1);");
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddDepartment()
        {
            var division = new Division { DivisionName = "STEM", Supervisor = SampleData.GetOneEmployee(_db, 1) };
            
            _db.Divisions.Add(division);
         
            _db.SaveChanges();
            Assert.Equal(1, _db.Divisions.Count());
        }
    }
}
