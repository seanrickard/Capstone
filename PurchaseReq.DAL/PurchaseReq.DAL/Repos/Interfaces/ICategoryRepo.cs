using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAllActiveCategories();

        Category GetCategoryWithOrders(int? id);

        IEnumerable<Category> GetAllWithOrders();
        
    }
}
