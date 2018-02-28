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
            CleanDatabase();
        }

        public void Dispose()
        {
            CleanDatabase();
            _db.Dispose();
        }

        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Delete from [User].[CFOs]");
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[User].[CFOs]\" , RESEED, 0);");
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddCFO()
        {
            var cfo = new CFO { Employee = SampleData.GetOneEmployee(_db), DateAdded = DateTime.Now };
            _db.CFOs.Add(cfo);
            _db.SaveChanges();
            Assert.Equal(1, _db.CFOs.Count());
        }
    }
}
