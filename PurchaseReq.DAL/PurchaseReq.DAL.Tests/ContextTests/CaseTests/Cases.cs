using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Linq;
using Xunit;

namespace PurchaseReq.DAL.Tests.ContextTests.CaseTests
{
    [Collection("PurchaseReq.DAL")]
    public class Cases : IDisposable
    {
        private readonly PurchaseReqContext _db;

        public Cases()
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

        //Add A Budget Code
        [Fact]
        public void Case3()
        {
            BudgetCode newBudget = new BudgetCode { Type = true, BudgetCodeName = "BakeSale Budget", Active = true, DA = 731180007, TotalAmount = 2461, Function =  41234, Project = 13415,  Parent = 41534};

            _db.BudgetCodes.Add(newBudget);
            _db.SaveChanges();
            int id = _db.BudgetCodes.Where(x => x.BudgetCodeName == "BakeSale Budget").ToList().First().Id;
            Assert.Equal("BakeSale Budget", _db.BudgetCodes.Find(id).BudgetCodeName);
        }

        [Fact]
        public void Case6()
        {
            Employee newHire = new Employee { FirstName = "Bob", LastName = "Ross", Active = true };
            _db.Employees.Add(newHire);

            _db.SaveChanges();

        }
    }
}
