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

        public void SeedData()
        {
            _context.Database.EnsureCreated();

            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(SampleData.GetEmployees(_context));
                _context.SaveChanges();
            }
            if(!_context.Divisions.Any())
            {
                _context.Divisions.AddRange(SampleData.GetDivisions(_context, SampleData.GetEmployees(_context)).ToList());
                _context.SaveChanges();
            }
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(SampleData.GetAllDepartments(_context));
                _context.SaveChanges();
            }

            _context.SaveChanges();
        }
    }
}
