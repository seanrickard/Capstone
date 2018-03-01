﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Initializers;
using PurchaseReq.Models.Entities;
using System;
using System.Linq;
using Xunit;

namespace PurchaseReq.DAL.Tests.ContextTests.CaseTests
{

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
            BudgetCode newBudget = new BudgetCode { Type = true, BudgetCodeName = "BakeSale Budget", Active = true, DA = 731180007, TotalAmount = 2461 };

            _db.BudgetCodes.Add(newBudget);
            _db.SaveChanges();
            var id = _db.BudgetCodes.Where(x => x.BudgetCodeName == "BakeSale Budget").ToList().First().Id;
            Assert.Equal("BakeSale Budget", _db.BudgetCodes.Find(id).BudgetCodeName);
        }
    }
}
