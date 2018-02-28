using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Linq;
using Xunit;

namespace PurchaseReq.DAL.Tests.ContextTests.UsersTests
{
    [Collection("PurchaseReq.DAL")]
    public class EmployeeTest : IDisposable
    {
        private readonly PurchaseReqContext _db;

        public EmployeeTest()
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
            _db.Employees.Add(SampleData.GetOneEmployee(_db));
            _db.SaveChanges();
            Assert.Equal(1, _db.Employees.Count());
        }

        [Fact]
        public void AddEmployeesFromSampleData()
        {
            foreach(var emp in SampleData.GetAllEmployees(_db))
            {
                _db.Employees.Add(emp);
            }
            _db.SaveChanges();
            Assert.Equal(3, _db.Employees.Count());
        }

        //  Ask Levi if this is how test should be done
        [Fact]
        public void DeleteEmployee()
        {
            var employee = new Employee { FirstName = "John", LastName = "Doe", Active = true };
            _db.Employees.Add(employee);
            _db.SaveChanges();
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            Assert.Equal(0, _db.Employees.Count());
        }
        // Test fails, but seems more like the proper way to run the test
        [Fact]
        public void DeleteEmployee2()
        {
            _db.Employees.Add(SampleData.GetOneEmployee(_db));
            _db.SaveChanges();
            _db.Employees.Remove(SampleData.GetOneEmployee(_db));
            _db.SaveChanges();
            Assert.Equal(0, _db.Employees.Count());
        }

        public void UpdateEmployeeDepartment()
        {
            
        }
    }
}
