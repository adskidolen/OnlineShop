namespace KeepHome.Web.Infrastructure
{
    using KeepHome.Models;
    using KeepHome.Web.Areas.Admin.ViewModels.ChildCategory;
    using KeepHome.Web.Areas.Admin.ViewModels.ParentCategory;
    using KeepHome.Web.Areas.Admin.ViewModels.Products;
    using KeepHome.Web.ViewModels.ShoppingBag;
    using KeepHome.Web.ViewModels.Home;

    using AutoMapper;
    using KeepHome.Web.ViewModels.ParentCategories;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ChildCategory, EditChildCategoryViewModel>();
            this.CreateMap<ChildCategory, AllChildCategoryViewModel>();
            this.CreateMap<Product, EditProductViewModel>();
            this.CreateMap<CreateProductViewModel, Product>();
            this.CreateMap<Product, ShoppingBagProductViewModel>();
            this.CreateMap<ParentCategory, ParentCategoryPartialViewModel>();
        }
    }
}