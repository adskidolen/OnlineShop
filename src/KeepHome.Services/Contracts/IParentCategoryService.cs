using System;
using System.Collections.Generic;
using System.Text;
using KeepHome.Models;

namespace KeepHome.Services.Contracts
{
    public interface IParentCategoryService
    {
        void AddMainCategory(string name, string imageUrl);

        IEnumerable<ParentCategory> GetCategories();

        ParentCategory GetCategoryById(int id);

        bool EditCategory(int id, string name,string imageUrl);

        bool DeleteCategory(int id);
    }
}
