using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PurchaseReq.DAL.EF;
using System;
using System.Linq;

namespace PurchaseReq.DAL.Initializers
{
    public class DbInitializer
    {
        private static readonly string[] Schema = { "User", "Order", "dbo" };

        public static void InitializeData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<PurchaseReqContext>();
            InitializeData(context);
        }

        public static void InitializeData(PurchaseReqContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
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
            ExecuteDeleteSQL(appDbContext, Schema[0], "BudgetAmounts");
            ExecuteDeleteSQL(appDbContext, Schema[0], "BudgetCodes");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Items");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Vendors");
            ExecuteDeleteSQL(appDbContext, Schema[0], "Rooms");
            ExecuteDeleteSQL(appDbContext, Schema[0], "Campuses");
            ExecuteDeleteSQL(appDbContext, Schema[0], "Addresses");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Categories");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Statuses");
            ExecuteDeleteSQL(appDbContext, Schema[1], "Approval");
            ResetIdentity(appDbContext);
        }

        private static void SetEmployeesToNull(PurchaseReqContext appDbContext)
        {
            appDbContext.Database.ExecuteSqlCommand("Update [dbo].[AspNetUsers] Set DepartmentId = NULL");
        }

        private static void ExecuteDeleteSQL(PurchaseReqContext appDbContext, string schema, string tableName)
        {
            appDbContext.Database.ExecuteSqlCommand("Delete from [" + schema + "].[" + tableName + "]");
        }

        private static void ResetIdentity(PurchaseReqContext appDbContext)
        {
            string[] UserTables = { "Departments", "Divisions", "BudgetCodes", "EmployeesBudgetCodes", "Rooms", "Campuses", "Addresses", "BudgetAmounts"};
            string[] OrderTables = { "Attachments", "Statuses", "Approval", "SupervisorApprovals", "Orders", "Requests", "Categories", "Items", "Vendors" };

            foreach(string table in UserTables)
            {
                appDbContext.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"["+ Schema[0] + "].[" + table + "]\", RESEED, 0);");
            }

            foreach (string table in OrderTables)
            {
                appDbContext.Database.ExecuteSqlCommand($"DBCC CHECKIDENT (\"[" + Schema[1] + "].[" + table + "]\", RESEED, 0);");
            }
        }

    public static void SeedData(PurchaseReqContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Employees.Any())
            {
                context.Employees.AddRange(SampleData.GetEmployees);
                context.SaveChanges();
            }
            if(!context.Divisions.Any())
            {
                context.Divisions.AddRange(SampleData.GetDivisions( context.Employees.ToList()));
                context.SaveChanges();
            }
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(SampleData.GetDepartments( context.Divisions.ToList()));
                context.SaveChanges();
                context.Employees.UpdateRange(SampleData.SetEmployeesDepartment(context.Employees.ToList()));
                context.SaveChanges();
            }
            if(!context.BudgetCodes.Any())
            {
                context.BudgetCodes.AddRange(SampleData.GetBudgetCodes);
                context.SaveChanges();
            }
            if(!context.EmployeesBudgetCodes.Any())
            {
                context.EmployeesBudgetCodes.AddRange(SampleData.GetEmployeeBudgetCodes(context.Employees.ToList(), context.BudgetCodes.ToList()));
                context.Employees.UpdateRange(SampleData.SetPasswords(context.Employees.ToList()));
                context.SaveChanges();
            }
            if(!context.Vendors.Any())
            {
                context.Vendors.AddRange(SampleData.GetVendors);
                context.SaveChanges();
            }
            if(!context.Statuses.Any())
            {
                context.Statuses.AddRange(SampleData.GetStatuses);
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(SampleData.GetCategories);
                context.SaveChanges();
            }
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(SampleData.GetOrders(context.Employees.ToList()));
                context.SaveChanges();
            }
            if (!context.Items.Any())
            {
                context.Items.AddRange(SampleData.GetItems);
                context.SaveChanges();
            }
            if (!context.Requests.Any())
            {
                context.Requests.AddRange(SampleData.GetRequests);
                context.SaveChanges();
            }      
            if (!context.Campuses.Any())
            {
                context.Campuses.AddRange(SampleData.GetCampuses);
                context.SaveChanges();
            }
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(SampleData.GetRooms);
                context.SaveChanges();
            }
            if (!context.Approval.Any())
            {
                context.Approval.AddRange(SampleData.GetApprovals);
                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
