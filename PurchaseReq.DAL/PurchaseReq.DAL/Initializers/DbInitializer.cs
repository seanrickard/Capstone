using System;
using System.Collections.Generic;
using System.Text;
using PurchaseReq.Models.Entities;
using PurchaseReq.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PurchaseReq.DAL.Initializers
{
    class DbInitializer
    {
        private readonly PurchaseReqContext _context;

        public DbInitializer(PurchaseReqContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if(!_context.Employees.Any())
            {
                _context.AddRange
                (
                    new Employee { FirstName = "John", LastName="Doe",  Active=true }    
                );
            }

            _context.SaveChanges();
        }
    }
}
