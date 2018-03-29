using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Linq;
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
        public void AddDepartment()
        {
            
            var department = new Department { DepartmentName = "Wood Chucks", Active = true, DivisionId = _db.Divisions.First().Id };
            _db.Departments.Add(department);
            _db.SaveChanges();
            Assert.Equal(9, _db.Departments.Count());
        }

        [Fact]
        public void AddEmployeeToDepartment()
        {

            var employee = new Employee { FirstName = "Chuck", LastName = "Wagons", Active = true, DepartmentId = _db.Departments.First().Id};
            _db.Employees.Add(employee);        
            
            Assert.Equal("Wagons", _db.Departments.First().Employees.Find(x => x.FirstName == "Chuck").LastName);
        }

        [Fact]
        public void AddDepartmentToDivision()
        {
            var dept = new Department { DepartmentName = "Basket Weaving", Active = false, DivisionId = _db.Divisions.First().Id};
            _db.Departments.Add(dept);
            _db.SaveChanges();
            var temp = _db.Departments.Where(x => x.DepartmentName == "Basket Weaving").ToList().First();
            
            Assert.Equal(temp.DivisionId , _db.Divisions.First().Id);
        }
    }
}
