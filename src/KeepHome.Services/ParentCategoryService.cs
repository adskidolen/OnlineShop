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
    public class ParentCategoryService:IParentCategoryService
    {
        private readonly KeepHomeContext db;

        public ParentCategoryService(KeepHomeContext db)
        {
            this.db = db;
        }

        public void AddMainCategory(string name)
        {
            var category = new ParentCategory()
            {
                Name = name
            };
            this.db.ParentCategories.Add(category);
            this.db.SaveChanges();
        }

        public IEnumerable<ParentCategory> GetCategories()
        {
            var categories = this.db.ParentCategories.Include(x => x.ChildCategories);
            return categories;
        }

        public ParentCategory GetCategoryById(int id)
        {
            var category = this.db.ParentCategories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        public bool EditCategory(int id, string name)
        {
            var category = this.db.ParentCategories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return false;
            }

            category.Name = name;
            this.db.SaveChanges();

            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = this.db.ParentCategories.Include(x => x.ChildCategories).FirstOrDefault(x => x.Id == id);

            if (category == null || category.ChildCategories.Count != 0)
            {
                return false;
            }

            this.db.ParentCategories.Remove(category);
            this.db.SaveChanges();

            return true;
        }
    }
}
