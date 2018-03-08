using System;
using System.Collections.Generic;
using System.Text;
using PurchaseReq.Models.Entities;
using PurchaseReq.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PurchaseReq.DAL.Initializers
{
    public class DbInitializer
    {
        private readonly PurchaseReqContext _context;
        private static readonly string[] TableName = { "Departments", "Divisions", "AspNetUsers",
        "Attachments", "Statuses", "BudgetCodes", "EmployeesBudgetCodes", "CFOs", "CFOApprovals",
        "Approvals", "SupervisorApprovals", "Orders", "Requests", "Categories", "Items", "Vendors", "AlternativeRequests"};
        private static string[] Schema = { "User", "Order", "dbo" };

        public DbInitializer(PurchaseReqContext appDbContext)
        {
            _context = appDbContext;
        }

        public static void ClearData(PurchaseReqContext appDbContext)
        {
            SetEmployeesToNull(appDbContext);
            ExecuteDeleteSQL(appDbContext, Schema[0], "Departments");
            ExecuteDeleteSQL(appDbContext, Schema[0], "Divisions");
            ExecuteDeleteSQL(appDbContext, Schema[0], "EmployeesBudgetCodes");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Requests");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Orders");
            ExecuteDeleteSQL(appDbContext, Schema[2], "AspNetUsers");
            ExecuteDeleteSQL(appDbContext, Schema[0], "BudgetCodes");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Items");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Vendors");
            ExecuteDeleteSQL(appDbContext, Schema[0], "Rooms");
            ExecuteDeleteSQL(appDbContext, Schema[0], "Buildings");
            ExecuteDeleteSQL(appDbContext, Schema[0], "Addresses");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Categories");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Statuses");
            ResetIdentity(appDbContext);
        }

        public static void SetEmployeesToNull(PurchaseReqContext appDbContext)
        {
            appDbContext.Database.ExecuteSqlCommand("Update [dbo].[AspNetUsers] Set DepartmentId = NULL");
        }

        public static void ExecuteDeleteSQL(PurchaseReqContext appDbContext, string schema, string tableName)
        {
            appDbContext.Database.ExecuteSqlCommand("Delete from [" + schema + "].[" + tableName + "]");
        }

        public static void ResetIdentity(PurchaseReqContext appDbContext)
        {
            string[] UserTables = { "Departments", "Divisions", "BudgetCodes", "EmployeesBudgetCodes", "CFOs", "Rooms", "Buildings", "Addresses"};
            string[] OrderTables = { "Attachments", "Statuses", "CFOApprovals", "Approval", "SupervisorApprovals", "Orders", "Requests", "Categories", "Items", "Vendors" };

            foreach(string table in UserTables)
            {
                appDbContext.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"["+ Schema[0] + "].[" + table + "]\", RESEED, 0);");
            }

            foreach (string table in OrderTables)
            {
                appDbContext.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[" + Schema[1] + "].[" + table + "]\", RESEED, 0);");
            }
        }

    public static void SeedData(PurchaseReqContext _context)
        {
            _context.Database.EnsureCreated();

            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(SampleData.GetEmployees);
                _context.SaveChanges();
            }
            if(!_context.Divisions.Any())
            {
                _context.Divisions.AddRange(SampleData.GetDivisions( _context.Employees.ToList()));
                _context.SaveChanges();
            }
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(SampleData.GetDepartments( _context.Divisions.ToList()));
                _context.SaveChanges();
                _context.Employees.UpdateRange(SampleData.SetEmployeesDepartment(_context.Employees.ToList()));
                _context.SaveChanges();
            }
            if(!_context.BudgetCodes.Any())
            {
                _context.BudgetCodes.AddRange(SampleData.GetBudgetCodes);
            }
            if(!_context.EmployeesBudgetCodes.Any())
            {
                _context.EmployeesBudgetCodes.AddRange(SampleData.GetEmployeeBudgetCodes);
            }
            if(!_context.Vendors.Any())
            {
                _context.Vendors.AddRange(SampleData.GetVendors);
            }
            if(!_context.Statuses.Any())
            {
                _context.Statuses.AddRange(SampleData.GetStatuses);
            }
            if (!_context.Categories.Any())
            {
                _context.Categories.AddRange(SampleData.GetCategories);
                _context.SaveChanges();
            }
            if (!_context.Orders.Any())
            {
                _context.Orders.AddRange(SampleData.GetOrders(_context.Employees.ToList()));
            }
            if (!_context.Items.Any())
            {
                _context.Items.AddRange(SampleData.GetItems);
                _context.SaveChanges();
            }
            if (!_context.Requests.Any())
            {
                _context.Requests.AddRange(SampleData.GetRequests);
            }      
            if (!_context.Buildings.Any())
            {
                _context.Buildings.AddRange(SampleData.GetBuildings);
                _context.SaveChanges();
            }
            if (!_context.Rooms.Any())
            {
                _context.Rooms.AddRange(SampleData.GetRooms);
            }

            _context.SaveChanges();
        }
    }
}
