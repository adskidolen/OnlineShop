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
    public class ShoppingBagService:IShoppingBagService
    {
        private readonly KeepHomeContext db;

        private readonly IProductService productService;
        private readonly IUserService userService;

        private const int DefaultQuantity = 1;


        public ShoppingBagService(KeepHomeContext db, IProductService productService, IUserService userService)
        {
            this.db = db;
            this.productService = productService;
            this.userService = userService; 
        }
        

        public void AddProduct(int productId, string username, int? quantity = null)
        {
            var product = this.productService.GetProduct(productId);
            var user = this.userService.GetUserByUsername(username);

            if (product == null || user == null)
            {
                return;
            }

            var shoppingBagProduct = GetShoppingBagProduct(productId, user.ShoppingBagId);

            if (shoppingBagProduct != null)
            {
                return;
            }

            shoppingBagProduct = new ShoppingBagProduct()
            {
                Product = product,
                Quantity = quantity == null ? DefaultQuantity : quantity.Value,
                ShoppingBagId = user.ShoppingBagId
            };

            this.db.ShoppingBagsProducts.Add(shoppingBagProduct);
            this.db.SaveChanges();
        }



        public void EditProduct(int productId, string username, int quantity)
        {
            var product = this.productService.GetProduct(productId);
            var user = this.userService.GetUserByUsername(username);

            if (product == null || user == null || quantity <= 0)
            {
                return;
            }
            var shoppingBagProduct = GetShoppingBagProduct(productId, user.ShoppingBagId);
            if (shoppingBagProduct == null)
            {
                return;
            }

            shoppingBagProduct.Quantity = quantity;

            this.db.ShoppingBagsProducts.Update(shoppingBagProduct);
            this.db.SaveChanges();
        }

        public ICollection<ShoppingBagProduct> GetAllShoppingBagProducts(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                return null;
            }

            return this.db.ShoppingBagsProducts.Include(x => x.Product)
                .Where(x => x.ShoppingBag.Customer.UserName == username).ToList();
        }

        public void DeleteProduct(int id, string username)
        {
            var product = this.productService.GetProduct(id);
            var user = this.userService.GetUserByUsername(username);

            if (product == null || user == null)
            {
                return;
            }

            var shoppingBag = GetShoppingBagProduct(product.Id, user.ShoppingBagId);

            this.db.ShoppingBagsProducts.Remove(shoppingBag);
            this.db.SaveChanges();
        }

        public void DeleteAllProduct(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                return;
            }

            var shoppingBagProducts = this.db.ShoppingBagsProducts
                .Where(x => x.ShoppingBagId == user.ShoppingBagId);

            this.db.ShoppingBagsProducts.RemoveRange(shoppingBagProducts);
            
            this.db.SaveChanges();
        }

        public bool AnyProducts(string username)
        {
            return this.db.ShoppingBagsProducts.Any(x => x.ShoppingBag.Customer.UserName == username);
        }

        private ShoppingBagProduct GetShoppingBagProduct(int productId, int userShoppingBagId)
        {
            return this.db.ShoppingBagsProducts
                .FirstOrDefault(x => x.ShoppingBagId == userShoppingBagId && x.ProductId == productId);
        }
    }
}