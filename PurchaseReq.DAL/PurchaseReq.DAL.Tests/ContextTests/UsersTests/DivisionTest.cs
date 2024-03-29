﻿using Microsoft.EntityFrameworkCore;
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
    public class DivisionTest : IDisposable
    {
        private readonly PurchaseReqContext _db;      

        public DivisionTest()
        {
            _db = new PurchaseReqContext();
            //CleanDatabase();
            DbInitializer.ClearData(_db);
            DbInitializer.SeedData(_db);
        }

        public void Dispose()
        {
            DbInitializer.SeedData(_db);
            //CleanDatabase();
            DbInitializer.ClearData(_db);
            _db.Dispose();
        }

        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Update [dbo].[AspNetUsers] Set DepartmentId = NULL");
            _db.Database.ExecuteSqlCommand("Delete from [User].[Departments]");
            _db.Database.ExecuteSqlCommand("Delete from [User].[Divisions]");
            _db.Database.ExecuteSqlCommand("Delete from [dbo].[AspNetUsers]");
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[User].[Divisions]\" , RESEED, 0);");
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[User].[Departments]\" , RESEED, 0);");
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddDivision()
        {
            var division = new Division { DivisionName = "Basket Weaving", SupervisorId = _db.Employees.Last().Id};
            _db.Divisions.Add(division);
            _db.SaveChanges();
            Assert.Equal(6, _db.Divisions.Count());
        }
    }
}
