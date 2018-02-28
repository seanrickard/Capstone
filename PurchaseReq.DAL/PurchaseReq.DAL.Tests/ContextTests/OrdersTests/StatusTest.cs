using System;
using PurchaseReq.Models.Entities;
using PurchaseReq.DAL.EF;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PurchaseReq.DAL.Tests.ContextTests.OrderTests
{
    [Collection("PurchaseReq.DAL")]
    public class StatusTest : IDisposable
    {
        private readonly PurchaseReqContext _db;


        public StatusTest()
        {
            _db = new PurchaseReqContext();
            CleanDatabase();
        }

        public void Dispose()
        {
            CleanDatabase();
            _db.Dispose();
        }

        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Delete from [Order].[Statuses]");
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[Order].[Statuses]\" , RESEED, 0);");
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddAStatus()
        {
            var status = new Status { StatusName = "Waiting for Supervisor Approval" };
            _db.Statuses.Add(status);
            _db.SaveChanges();
            Assert.Equal(1, _db.Statuses.Count());
        }
    }
}
