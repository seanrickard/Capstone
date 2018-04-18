using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
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
        public void AddEmployee()
        {
            var count = _db.Employees.Count();
            _db.Employees.Add(new Employee { FirstName = "Bob", LastName = "Bobnby", Active = true});
            _db.SaveChanges();
            Assert.Equal(count + 1, _db.Employees.Count());
        }


        [Fact]
        public void DeleteEmployee()
        {
            var count = _db.Employees.Count();
            Employee employee = (Employee)_db.Employees.Where(x => x.FirstName == "David").ToList().First();
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            Assert.Equal(count - 1, _db.Employees.Count());
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

        [Fact]
        public void GiveEmployeeABudget()
        {
            Employee employee = _db.Employees.Where(x => x.FirstName == "Charles").ToList().First();
            BudgetCode code = _db.BudgetCodes.Where(x => x.BudgetCodeName == "CS Budget").ToList().First();
            string id = employee.Id;

            employee.EmployeesBudgetCode = new List<EmployeesBudgetCodes> {
                new EmployeesBudgetCodes
                {
                    Employee = employee,
                    BudgetCode = code,
                }
            };

            _db.SaveChanges();

            Assert.Equal(id, _db.EmployeesBudgetCodes.Where(x => x.EmployeeId == id).ToList().First().EmployeeId);
        }
    }
}
