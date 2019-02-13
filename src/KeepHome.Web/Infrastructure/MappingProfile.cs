using KeepHome.Web.ViewModels.Orders;

namespace KeepHome.Web.Infrastructure
{
    using KeepHome.Models;
    using KeepHome.Web.Areas.Admin.ViewModels.ChildCategory;
    using KeepHome.Web.Areas.Admin.ViewModels.ParentCategory;
    using KeepHome.Web.Areas.Admin.ViewModels.Products;
    using KeepHome.Web.ViewModels.ShoppingBag;

    using AutoMapper;
    using KeepHome.Web.ViewModels.ParentCategories;
    using KeepHome.Web.ViewModels.ChildCategories;
    using KeepHome.Web.ViewModels.Products;
    using KeepHome.Web.ViewModels.Address;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ParentCategory, ViewModels.ParentCategories.ParentCategoryViewModel>();

            this.CreateMap<ChildCategory, EditChildCategoryViewModel>();
            this.CreateMap<ChildCategory, AllChildCategoryViewModel>();
            this.CreateMap<ChildCategory, ChildCategoryDetailsViewModel>();

            this.CreateMap<Product, EditProductViewModel>();
            this.CreateMap<Product, ShoppingBagProductViewModel>();
            this.CreateMap<Product, ProductDetailsViewModel>();

            this.CreateMap<CreateProductViewModel, Product>();

            this.CreateMap<AddressInputModel, Address>();
            this.CreateMap<AddressInputModel, Address>();
            
        }
    }
}