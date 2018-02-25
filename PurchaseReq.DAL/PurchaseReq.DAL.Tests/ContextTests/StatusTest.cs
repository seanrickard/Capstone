using System;
using System.Collections.Generic;
using System.Text;
using PurchaseReq.Models.Entities;
using PurchaseReq.DAL.EF;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PurchaseReq.DAL.Tests.ContextTests
{
    public class StatusTest : IDisposable
    {
        private readonly PurchaseReqContext _db;


        public StatusTest()
        {
            _db = new PurchaseReqContext();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Delete from Order.Status");
            _db.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"Order.Status\" , RESEED, -1);");
        }
    }
}
