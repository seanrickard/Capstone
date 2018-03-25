using PurchaseReq.Models.Entities;
using System.Collections.Generic;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface ICategoryRepo
    {
<<<<<<< HEAD
        IEnumerable<Category> GetAllActiveCategories();

        Category GetCategoryWithOrders(int? id);

        IEnumerable<Category> GetAllWithOrders();
=======
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
>>>>>>> f5147f77345a30377f520d57ebb60308c43e35d7
    }
}
