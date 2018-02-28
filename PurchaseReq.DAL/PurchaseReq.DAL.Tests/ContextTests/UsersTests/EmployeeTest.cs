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
            var employee = _db.Employees.First();
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            Assert.Equal(0, _db.Employees.Count());
        }

        [Fact]
        public void UpdateEmployeeDepartment()
        {
            var employee = SampleData.GetOneEmployee(_db);
            _db.Divisions.Add(SampleData.GetOneDivision(_db));
            _db.Departments.AddRange(SampleData.GetAllDepartments(_db));
            _db.Employees.Add(employee);
            _db.SaveChanges();
            employee = _db.Employees.First();
            employee.DepartmentId = 1;
            _db.Employees.Update(employee);
            _db.SaveChanges();
            Assert.Equal("Jane", _db.Departments.First().Employees.First().FirstName);
           // Assert.Equal(2, _db.Employees.First().DepartmentId);
        }

        [Fact]
        public void ReadEmployee()
        {
            var employee = SampleData.GetOneEmployee(_db);
            _db.Employees.Add(employee);
            _db.SaveChanges();
            Assert.Equal("Jane", _db.Employees.First().FirstName);
        }
    }
}
