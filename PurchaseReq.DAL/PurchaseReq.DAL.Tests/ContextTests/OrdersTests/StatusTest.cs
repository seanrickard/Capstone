using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Linq;
<<<<<<< HEAD
using Xunit;
=======
using PurchaseReq.DAL.Initializers;
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7

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

<<<<<<< HEAD
=======
     
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
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
            var count = _db.Statuses.Count();
            _db.Statuses.Add(status);
            _db.SaveChanges();
            Assert.Equal(count + 1, _db.Statuses.Count());
        }

        [Fact]
        public void DeleteAStatus()
        {
            var status = new Status { StatusName = "Waiting for Supervisor Approval" };
            _db.Statuses.Add(status);
            _db.SaveChanges();
<<<<<<< HEAD
            Assert.Equal(beforeCount + 1, _db.Statuses.Count());
=======
            var count = _db.Statuses.Count();
            _db.Statuses.Remove(status);
            _db.SaveChanges();
            Assert.Equal(count - 1, _db.Statuses.Count());
        }

        [Fact]
        public void UpdateAStatus()
        {
            Status status = _db.Statuses.FirstOrDefault();
            status.StatusName = "Updated Name";
            _db.Update(status);
            _db.SaveChanges();
            Assert.Equal("Updated Name", _db.Statuses.FirstOrDefault().StatusName);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
        }
    }
}
