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

        public DbInitializer(PurchaseReqContext appDbContext)
        {
            _context = appDbContext;
        }

        public static void ClearData(PurchaseReqContext appDbContext)
        {

        }

        public static void ExecuteDeleteSQL(PurchaseReqContext appDbContext, string schema, string tableName)
        {

        }

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
