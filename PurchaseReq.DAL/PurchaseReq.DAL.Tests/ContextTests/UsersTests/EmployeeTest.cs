using Microsoft.AspNetCore.Identity;
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
            DbInitializer.ClearData(_db);
            //CleanDatabase();
            DbInitializer.SeedData(_db);
        }

        public void Dispose()
        {
            //CleanDatabase();
            DbInitializer.ClearData(_db);
            _db.Dispose();
        }

        //private void CleanDatabase()
        //{
        //    _db.Database.ExecuteSqlCommand("Update [dbo].[AspNetUsers] Set DepartmentId = NULL");
        //    _db.Database.ExecuteSqlCommand("Delete from [User].[Departments]");
        //    _db.Database.ExecuteSqlCommand("Delete from [User].[Divisions]");
        //    _db.Database.ExecuteSqlCommand("Delete from [dbo].[AspNetUsers]");
        //    _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[User].[Divisions]\" , RESEED, 0);");
        //    _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[User].[Departments]\" , RESEED, 0);");
        //}

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddEmployee()
        {
            _db.Employees.Add(new Employee { FirstName = "Bob", LastName = "Bobnby", Active = true});
            _db.SaveChanges();
            Assert.Equal(9, _db.Employees.Count());
        }


        //  Ask Levi if this is how test should be done
        [Fact]
        public void DeleteEmployee()
        {
            Employee employee = (Employee)_db.Employees.Where(x => x.FirstName == "David").ToList().First();
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            Assert.Equal(7, _db.Employees.Count());
        }

        [Fact]
        public void UpdateEmployeeDepartment()
        {
            Employee employee = (Employee)_db.Employees.Where(x => x.FirstName == "David").ToList().First();
            var id = employee.Id;
            employee.FirstName = "Davvy";
            employee.LastName = "Lockers";
            _db.Employees.Update(employee);
            _db.SaveChanges();
            Assert.Equal("Davvy", _db.Employees.Find(id).FirstName);
            // Assert.Equal(2, _db.Employees.First().DepartmentId);
        }

        [Fact]
        public void ReadEmployee()
        {
            Employee employee = (Employee)_db.Employees.Where(x => x.FirstName == "Charles").ToList().First();
            var id = employee.Id;
            Assert.Equal("Almond", _db.Employees.Find(id).LastName);
        }

    }
}
