using PurchaseReq.DAL.EF;
using System;
using Xunit;

namespace PurchaseReq.DAL.Tests.ContextTests.UsersTests
{
    [Collection("PurchaseReq.DAL")]
    public class CFOTest : IDisposable
    {
        private readonly PurchaseReqContext _db;

        public CFOTest()
        {
            _db = new PurchaseReqContext();
        }

        public void Dispose()
        {
            _db.Dispose();
        }


        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        //[Fact]
        //public void AddCFO()
        //{
        //    var cfo = new CFO { Employee = SampleData.GetOneEmployee(_db), DateAdded = DateTime.Now };
        //    _db.CFOs.Add(cfo);
        //    _db.SaveChanges();
        //    Assert.Equal(1, _db.CFOs.Count());
        //}
    }
}
