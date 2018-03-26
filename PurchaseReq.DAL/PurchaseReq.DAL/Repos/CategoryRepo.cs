using Microsoft.EntityFrameworkCore;
using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.DAL.Repos.Interfaces;
using PurchaseReq.Models.Entities;
using System.Collections.Generic;
using System.Linq;



namespace PurchaseReq.DAL.Repos
{
    public class CategoryRepo : RepoBase<Category>, ICategoryRepo
    {

        public IEnumerable<Category> GetAllActiveCategories()
            => Table.Where(x => x.Active == true).ToList();

        public Category GetCategoryWithOrders(int? id)
            => Table.Include(x => x.Orders).SingleOrDefault(x => x.Id == id);


        public IEnumerable<Category> GetAllWithOrders()
            => Table.Include(x => x.Orders).ToList();


    }
}
