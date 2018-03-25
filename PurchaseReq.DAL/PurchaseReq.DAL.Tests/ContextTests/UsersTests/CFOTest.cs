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
<<<<<<< HEAD
=======
            DbInitializer.ClearData(_db);
            DbInitializer.SeedData(_db);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
        }

        public void Dispose()
        {
<<<<<<< HEAD
            _db.Dispose();
        }


=======
            DbInitializer.ClearData(_db);
            _db.Dispose();
        }

    
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void AddCFO()
        {
            CFO newCFO = new CFO { };
            
           // _db.CFOs.Add(cfo);
            _db.SaveChanges();
            Assert.Equal(1, _db.CFOs.Count());
        }
    }
}
