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
            _db.Database.ExecuteSqlCommand("Delete from [User].[Divisions]");
            _db.Database.ExecuteSqlCommand("Delete from [dbo].[AspNetUsers]");
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[User].[Divisions]\" , RESEED, -1);");
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
            _db.Employees.Add(SampleData.GetOneEmployee(_db));
            _db.SaveChanges();
            var employee = _db.Employees.First();
            var division = new Division { DivisionName = "STEM", Supervisor = employee };
            _db.Divisions.Add(division);
            _db.SaveChanges();
            var department = new Department { DepartmentName = "Computer Science", Active = true , DivisionId = _db.Divisions.First().Id};
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
            ;
            _db.Employees.Add(employee);
            _db.SaveChanges();

            employee.DepartmentId = 0;

            _db.Employees.Update(employee);
            //_db.Departments.First().Employees.Add(employee);
            _db.SaveChanges();

            Assert.Equal(0, _db.Departments.First().Employees.First().DepartmentId);
        }
    }
}
