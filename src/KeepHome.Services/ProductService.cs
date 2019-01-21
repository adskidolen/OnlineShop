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
    public class ProductService:IProductService
    {
        private readonly KeepHomeContext db;

        public ProductService(KeepHomeContext db)
        {
            this.db = db;
        }

        public Product GetProduct(int id)
        {
            var product = this.db.Products.Include(x => x.ChildCategory).FirstOrDefault(m => m.Id == id);
            return product;
        }

        public IEnumerable<ChildCategory> GetChildCategories()
        {
            return this.db.ChildCategories;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.db.Products.Include(x => x.ChildCategory).ThenInclude(x => x.ParentCategory);
        }

        public IEnumerable<Product> GetProductsByCategory(int? childCategoryId)
        {
            return db.Products.Where(x => x.ChildCategory.Id == childCategoryId)
                .Include(p => p.ChildCategory);
        }

        public void AddProduct(Product product)
        {
            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            this.db.Products.Update(product);
            this.db.SaveChanges();
        }

        public void RemoveProduct(int productId)
        {
            var product = this.db.Products.FirstOrDefault(x => x.Id == productId);

            //TODO:Виж това щото няма да ти хареса със сиг 
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }
    }
}