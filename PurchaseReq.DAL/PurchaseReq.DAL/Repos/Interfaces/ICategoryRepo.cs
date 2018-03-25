using PurchaseReq.DAL.Repos.Base;
using PurchaseReq.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseReq.DAL.Repos.Interfaces
{
    public interface ICategoryRepo : IRepo<Category>
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
    }
}
