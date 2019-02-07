namespace KeepHome.Web.Infrastructure
{
    using KeepHome.Models;
    using KeepHome.Web.Areas.Admin.ViewModels.ChildCategory;
    using KeepHome.Web.Areas.Admin.ViewModels.ParentCategory;
    using KeepHome.Web.Areas.Admin.ViewModels.Products;
    using KeepHome.Web.ViewModels.ShoppingBag;

    using AutoMapper;
    using KeepHome.Web.ViewModels.ParentCategories;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ParentCategory, ParentCategoryDetailsViewModel>();
            this.CreateMap<ParentCategory, ViewModels.ParentCategories.ParentCategoryViewModel>();

            this.CreateMap<ChildCategory, EditChildCategoryViewModel>();
            this.CreateMap<ChildCategory, AllChildCategoryViewModel>();

            this.CreateMap<Product, EditProductViewModel>();
            this.CreateMap<Product, ShoppingBagProductViewModel>();

            this.CreateMap<CreateProductViewModel, Product>();
        }
    }
}