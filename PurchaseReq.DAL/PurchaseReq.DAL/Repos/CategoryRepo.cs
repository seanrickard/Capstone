using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
=======
using PurchaseReq.DAL.EF;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Linq;
using System;
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
using System.Collections.Generic;
using System.Linq;


namespace PurchaseReq.DAL.Repos
{
    public class CategoryRepo : RepoBase<Category>, ICategoryRepo
    {
<<<<<<< HEAD
        public IEnumerable<Category> GetAllActiveCategories()
            => Table.Where(x => x.Active == true);

        public Category GetCategoryWithOrders(int? id)
            => Table.Include(x => x.Orders).SingleOrDefault(x => x.Id == id);


        public IEnumerable<Category> GetAllWithOrders()
            => Table.Include(x => x.Orders);
=======
        public CategoryRepo(DbContextOptions<PurchaseReqContext> options) : base(options)
        {

        }

        public IEnumerable<Category> GetAllCategories() => Table.OrderBy(x => x.CategoryName);


        public Category GetCategoryById(int categoryId) => Table.FirstOrDefault(x => x.Id == categoryId);
        
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
