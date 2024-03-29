﻿using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.DAL.Repos;
using PurchaseReq.Models.Entities;
using System;
using System.Linq;
using Xunit;

namespace PurchaseReq.DAL.Tests.ContextTests.OrdersTests
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
            OrderRepo repo = new OrderRepo(new RequestRepo());
            var model = repo.GetAllWaitingForCFO();
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

        [Fact]
        public void DeleteAStatus()
        {
            var status = new Status { StatusName = "Waiting for Supervisor Approval" };
            _db.Statuses.Add(status);
            _db.SaveChanges();

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
        }
    }
}
