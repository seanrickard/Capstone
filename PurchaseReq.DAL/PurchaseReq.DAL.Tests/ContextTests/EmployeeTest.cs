using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
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
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[dbo].[AspNetUsers]\" , RESEED, -1);");
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddEmployee()
        {
            //var division = new Division{ Id = 1, DivisionName= "ComputerDivision" };
            //var department = new Department { Id = 1, DepartmentName = "Computers" };
            //var employee = new Employee { FirstName = "John", LastName="Doe", Active=true, DepartmentId=1  };
            //_db.Departments.Add(department);
            //_db.Divisions.Add(division);
            //_db.Employees.Add(employee);
            //_db.SaveChanges();
            //Assert.Equal(1, _db.Employees.Count());
        }
    }
}
