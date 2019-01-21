using System;
using System.Collections.Generic;
using System.Text;
using KeepHome.Models;

namespace KeepHome.Services.Contracts
{
    public interface IParentCategoryService
    {
        void AddMainCategory(string name);

        IEnumerable<ParentCategory> GetCategories();

        ParentCategory GetCategoryById(int id);

        bool EditCategory(int id, string name);

        bool DeleteCategory(int id);
    }
}
