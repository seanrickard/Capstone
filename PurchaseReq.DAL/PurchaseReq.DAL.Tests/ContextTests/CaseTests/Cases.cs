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

        //Configuring the PRS with college data
        [Fact]
        public void Case01()
        {
            Campus MainCampus = new Campus { CampusName = "WVUP Main Campus", Address = new Address { StreetAddress = "300 Campus Dr.", City = "Parkersburg", State = "WV", Zip = "25550" } };

            _db.Campuses.Add(MainCampus);
            _db.SaveChanges();
            int id = _db.Campuses.Where(x => x.CampusName == "Main Campus").ToList().First().Id;
            Assert.Equal("Main Campus", _db.Campuses.Find(id).CampusName);
        }

        //Configuring the college organization hierarchy
        [Fact]
        public void Case02()
        {
            //  need to do Identity roles
        }

        //Creating a new budget for a new college program
        [Fact]
        public void Case03()
        {
            BudgetCode newBudget = new BudgetCode { Type = true, BudgetCodeName = "BakeSale Budget", Active = true, DA = 731180007};

            _db.BudgetCodes.Add(newBudget);
            _db.SaveChanges();
            int id = _db.BudgetCodes.Where(x => x.BudgetCodeName == "BakeSale Budget").ToList().First().Id;
            Assert.Equal("BakeSale Budget", _db.BudgetCodes.Find(id).BudgetCodeName);
        }

        // Deactivating a budget for a cancelled college program
        // the first case4 in the requirements doc
        [Fact]
        public void Case04()
        {

            BudgetCode tempBudgetCode = (BudgetCode)_db.BudgetCodes.Where(x => x.DA == 731180007).ToList().First();

            tempBudgetCode.Active = false;
            _db.BudgetCodes.Update(tempBudgetCode);
            _db.SaveChanges();

            Assert.False(_db.BudgetCodes.Where(x => x.DA == 731180007).ToList().First().Active);
        }

        // Updating a budget with new annual budget information
        //the second case4 in the requirements doc
        [Fact]
        public void CaseFour()
        {
            BudgetCode tempBudgetCode = _db.BudgetCodes.Where(x => x.DA == 731180007).ToList().First();
            //tempBudgetCode.TotalAmount = 7000;
            _db.BudgetCodes.Update(tempBudgetCode);
            _db.SaveChanges();

            //Assert.Equal(7000, _db.BudgetCodes.Where(x => x.DA == 731180007).ToList().First().TotalAmount);
        }

        // Updating a budget with monies collected from lab fees
        [Fact]
        public void Case05()
        {
            BudgetCode tempBudgetCode = _db.BudgetCodes.Where(x => x.BudgetCodeName == "CS Budget").ToList().First();
           // decimal CSBudget = _db.BudgetCodes.Where(x => x.BudgetCodeName == "CS Budget").ToList().First().TotalAmount;
           // tempBudgetCode.TotalAmount += 2000;
            _db.Update(tempBudgetCode);
            _db.SaveChanges();
            //Assert.Equal(CSBudget + 2000, _db.BudgetCodes.Where(x => x.BudgetCodeName == "CS Budget").ToList().First().TotalAmount);
        }

        [Fact]
        public void Case06()
        {
            Employee newHire = new Employee { FirstName = "Bob", LastName = "Ross", Active = true };
            _db.Employees.Add(newHire);

            _db.SaveChanges();

        }

        // Updating user accounts when a personnel change occurs
        [Fact]      //see notes for questions for levi
        public void Case07()
        {
            Employee newHireCFO = new Employee { FirstName = "Andy", LastName = "CFO", Active = true };
            _db.Employees.Add(newHireCFO);
            _db.SaveChanges();
            string newCFOEmployeeId = _db.Employees.Where(x => x.FirstName == "Andy").ToList().First().Id;
            //Employee oldCFO = _db.CFOs.Where(x => x.Id == 1).ToList().First().Employee;
           // oldCFO.Active = false;
            //CFO newCFO = new CFO { EmployeeId = newCFOEmployeeId, DateAdded = DateTime.Now };
            //_db.CFOs.Add(newCFO);
            _db.SaveChanges();
            //Assert.False(_db.CFOs.Where(x => x.Id == 1).ToList().First().Employee.Active);

            //Assert.Equal("Andy", _db.CFOs.Where(x => x.Id == 2).ToList().First().Employee.FirstName);

        }

        // Creating a new purchase req with items less than $3000
        [Fact]
        public void Case08()
        {
            Request newReq = new Request
            {
                OrderId = 5,
                ItemId = 5,
                EstimatedCost = 54,
                QuantityRequested = 4,
                EstimatedTotal = 54 * 4,
                Chosen = true,
                VendorId = 3
            };

            int currentTotalReqs = _db.Requests.Count();

            _db.Requests.Add(newReq);
            _db.SaveChanges();

            Assert.Equal(currentTotalReqs + 1, _db.Requests.Count());
        }

        //Creating a new purchase req with items greater than 3000
        [Fact]
        public void Case09()
        {

        }

        // creating a new purchase req with items greater than 3000 but on a state budget
        [Fact]
        public void Case10()
        {

        }

        // Reviewing the status of already submitted purchase req
        [Fact]
        public void Case11()
        {
//            Employee tempEmployee = _db.Employees.ToList().First();
//            Order tempOrder = _db.Orders.Where(x => x.Employee.Id == tempEmployee.Id).ToList().First();
//            Status tempStatus = tempOrder.Status;
//
//            Assert.Equal(tempStatus, _db.Orders.Where(x => x.EmployeeId == tempEmployee.Id).ToList().First().Status);

            // I dunno if this test even qualifies.. it's basically testing a read, and 
            // should probably just be done after we get views to work with
        }
        
        // Approving a purchase requisition
        [Fact]
        public void Case12()
        {

        }
    }
}
