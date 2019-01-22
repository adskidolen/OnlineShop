namespace KeepHome.Web.Areas.Admin.Controllers
{
    using KeepHome.Web.Areas.Admin.Controllers.Base;
    using KeepHome.Web.Areas.Admin.ViewModels.Products;

    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : AdminBaseController
    {
        public IActionResult Create() => this.View();

        [HttpPost]
        public IActionResult Create(CreateProductInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.RedirectToAction();
        }
    }
}