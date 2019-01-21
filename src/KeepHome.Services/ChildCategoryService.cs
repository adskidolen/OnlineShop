using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeepHome.Data;
using KeepHome.Models;
using KeepHome.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KeepHome.Services
{
    public class ChildCategoryService:IChildCategoryService
    {
        private readonly KeepHomeContext db;

        public ChildCategoryService(KeepHomeContext db)
        {
            this.db = db;
        }


        public IEnumerable<ChildCategory> GetChildCategories()
        {
            var childCategories = this.db.ChildCategories.Include(x => x.Products).Include(x => x.ParentCategory);
            return childCategories;
        }

        public ChildCategory GetChildCategoryById(int id)
        {
            var childCategory = this.db.ChildCategories.FirstOrDefault(x => x.Id == id);
            return childCategory;
        }

        public ChildCategory CreateChildCategory(string name, int categoryId)
        {
            var childCategory = new ChildCategory
            {
                Name = name,
                ParentCategoryId = categoryId
            };

            this.db.ChildCategories.Add(childCategory);
            this.db.SaveChanges();

            return childCategory;
        }

        public bool EditChildCategory(int id, string name, int categoryId)
        {
            var childCategory = this.db.ChildCategories.FirstOrDefault(x => x.Id == id);
            if (childCategory == null)
            {
                return false;
            }

            childCategory.Name = name;
            childCategory.ParentCategoryId = categoryId;

            this.db.SaveChanges();

            return true;
        }

        public bool DeleteChildCategory(int id)
        {
            var category = this.db.ChildCategories.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

            if (category == null || category.Products.Any())
            {
                return false;
            }

            this.db.ChildCategories.Remove(category);
            this.db.SaveChanges();

            return true;
        }
    }
}
