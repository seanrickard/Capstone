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
    public class DepartmentTest : IDisposable
    {
        private readonly PurchaseReqContext _db;


        public DepartmentTest()
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
            _db.Database.ExecuteSqlCommand("Delete from [User].[Departments]");
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[User].[Departments]\" , RESEED, -1);");
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddDepartment()
        { 
            var department = new Department { DepartmentName = "Computer Science", Active = true };
            _db.Departments.Add(department);
            _db.SaveChanges();
            Assert.Equal(1, _db.Departments.Count());
        }

        [Fact]
        public void AddDepartmentsFromSampleData()
        {
            foreach (var dept in SampleData.GetAllDepartments(_db))
            {
                _db.Departments.Add(dept);
            }
            _db.SaveChanges();
            Assert.Equal(3, _db.Departments.Count());
        }

        [Fact]
        public void AddEmployeeToDepartment()
        {
            foreach (var dept in SampleData.GetAllDepartments(_db))
            {
                _db.Departments.Add(dept);
            }
            _db.SaveChanges();
            var employee = SampleData.GetOneEmployee(_db);
            _db.Employees.Add(employee);
            _db.Employees.First().DepartmentId = 0;
            _db.Employees.Update(employee);
            //_db.Departments.First().Employees.Add(employee);
            _db.SaveChanges();
            Assert.Equal("Jane", _db.Departments.First().Employees.First().FirstName);
        }
    }
}
