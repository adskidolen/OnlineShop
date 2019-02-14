using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeepHome.Data;
using KeepHome.Web.Controllers.Base;
using KeepHome.Web.ViewModels.Home;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;

namespace KeepHome.Web.Controllers
{
    public class SearchController:BaseController
    {
        private readonly KeepHomeContext db;

        public SearchController(KeepHomeContext db)
        {
            this.db = db;
        }
        public IActionResult GetProduct(IndexViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Text))
            {
                model.Products = this.db.Products.FullTextSearchQuery(model.Text);

            }
            else
            {
                model.Products = db.Products;
            }
            return View(model);
        }
    }
}
