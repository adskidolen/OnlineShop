using System;
using System.Collections.Generic;
using System.Text;
using KeepHome.Models;

namespace KeepHome.Services.Contracts
{
    public interface IProductService
    {
        Product GetProduct(int id);
        IEnumerable<ChildCategory> GetChildCategories();
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(int? childCategoryId);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void RemoveProduct(int productId);
    }
}
