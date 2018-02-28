﻿using Microsoft.EntityFrameworkCore;
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
    public class EmployeeTest : IDisposable
    {
        private readonly PurchaseReqContext _db;

        private DbInitializer dbInitializer; 


        public EmployeeTest()
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
            _db.Database.ExecuteSqlCommand("Delete from [dbo].[AspNetUsers]");
            //_db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[dbo].[AspNetUsers]\" , RESEED, -1);");
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddEmployee()
        {
            
           // var employee = new Employee { FirstName = "John", LastName = "Doe", Active = true, DepartmentId = 1 };
            //_db.Departments.Add(department);
            //_db.Divisions.Add(division);
            
            _db.SaveChanges();
            Assert.Equal(2, _db.Employees.Count());
        }
    }
}
