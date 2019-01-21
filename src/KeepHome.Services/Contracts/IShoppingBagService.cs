using System;
using System.Collections.Generic;
using System.Text;
using KeepHome.Models;

namespace KeepHome.Services.Contracts
{
    public interface IShoppingBagService
    {
        void AddProduct(int productId, string username, int? quantity = null);

        void EditProduct(int productId, string username, int quantity);

        ICollection<ShoppingBagProduct> GetAllShoppingBagProducts(string username);

        void DeleteProduct(int id, string username);

        void DeleteAllProduct(string username);

        bool AnyProducts(string username);
    }
}
