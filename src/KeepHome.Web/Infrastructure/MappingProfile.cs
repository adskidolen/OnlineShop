using KeepHome.Models;
using KeepHome.Web.Areas.Admin.ViewModels.ChildCategory;
using KeepHome.Web.Areas.Admin.ViewModels.ParentCategory;
using KeepHome.Web.Areas.Admin.ViewModels.Products;
using KeepHome.Web.ViewModels.ShoppingBag;

namespace KeepHome.Web.Infrastructure
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ParentCategory, ParentCategoryViewModel>();
            this.CreateMap<ChildCategory, EditChildCategoryViewModel>();
            this.CreateMap<ChildCategory, AllChildCategoryViewModel>();
            this.CreateMap<Product, EditProductViewModel>();
            this.CreateMap<CreateProductViewModel, Product>();
            this.CreateMap<Product,ShoppingBagProductViewModel>();
        }
    }
}