using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Linq;
using Xunit;

namespace PurchaseReq.DAL.Tests.ContextTests.OrderTests
{
    [Collection("PurchaseReq.DAL")]
    public class StatusTest : IDisposable
    {
        private readonly PurchaseReqContext _db;


        public StatusTest()
        {
            _db = new PurchaseReqContext();
            DbInitializer.ClearData(_db);
            DbInitializer.SeedData(_db);
        }

        public void Dispose()
        {
            DbInitializer.ClearData(_db);
            _db.Dispose();
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddAStatus()
        {
            int beforeCount = _db.Statuses.Count();
            var status = new Status { StatusName = "Waiting for Supervisor Approval" };
            _db.Statuses.Add(status);
            _db.SaveChanges();
            Assert.Equal(beforeCount + 1, _db.Statuses.Count());
        }
    }
}
