﻿using System;
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
        private static readonly string[] Schema = { "Users", "Orders" };

        public DbInitializer(PurchaseReqContext appDbContext)
        {
            _context = appDbContext;
        }

        public static void ClearData(PurchaseReqContext appDbContext)
        {
            SetEmployeesToNull(appDbContext);
            ExecuteDeleteSQL(appDbContext, Schema[0], "Departments");
            ExecuteDeleteSQL(appDbContext, Schema[0], "Divisions");
            ExecuteDeleteSQL(appDbContext, Schema[0], "AspNetUsers");
            ExecuteDeleteSQL(appDbContext, Schema[0], "EmployeesBudgetCodes");
            ExecuteDeleteSQL(appDbContext, Schema[0], "BudgetCodes");
            //ResetIdentity(appDbContext);
        }

        public static void SetEmployeesToNull(PurchaseReqContext appDbContext)
        {
            appDbContext.Database.ExecuteSqlCommand("Update [dbo].[AspNetUsers] Set DepartmentId = NULL");
        }

        public static void ExecuteDeleteSQL(PurchaseReqContext appDbContext, string schema, string tableName)
        {
            appDbContext.Database.ExecuteSqlCommand($"Delete from {schema}.{tableName}");
        }

        //public static void ResetIdentity(PurchaseReqContext appDbContext)
        //{
        //    private static readonly string[] TableName = {, "AspNetUsers",
        //"Attachments", "Statuses", , "EmployeesBudgetCodes", "CFOs", "CFOApprovals",
        //"Approvals", "SupervisorApprovals", "Orders", "Requests", "Categories", "Items", "Vendors", "AlternativeRequests"};
        //    string[] UserTable = { "Departments", "Divisions", "BudgetCodes", }


        //}

        public static void SeedData(PurchaseReqContext _context)
        {
            _context.Database.EnsureCreated();

            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(SampleData.GetEmployees(_context));
                _context.SaveChanges();
            }
            if(!_context.Divisions.Any())
            {
                _context.Divisions.AddRange(SampleData.GetDivisions(_context, _context.Employees.ToList()));
                _context.SaveChanges();
            }
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(SampleData.GetDepartments(_context, _context.Divisions.ToList()));
                _context.SaveChanges();
                _context.Employees.UpdateRange(SampleData.SetEmployeesDepartment(_context.Employees.ToList()));
                _context.SaveChanges();
            }

            _context.SaveChanges();
        }
    }
}
