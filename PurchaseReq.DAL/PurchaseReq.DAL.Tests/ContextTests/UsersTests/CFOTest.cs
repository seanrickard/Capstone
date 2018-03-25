using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PurchaseReq.DAL.Tests.ContextTests.UsersTests
{
    [Collection("PurchaseReq.DAL")]
    public class CFOTest : IDisposable
    {
        private readonly PurchaseReqContext _db;

        public CFOTest()
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
        public void AddCFO()
        {
            CFO newCFO = new CFO { };
            
           // _db.CFOs.Add(cfo);
            _db.SaveChanges();
            Assert.Equal(1, _db.CFOs.Count());
        }
    }
}
