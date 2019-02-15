namespace KeepHome.Web.Infrastructure
{
    using AutoMapper;

    using KeepHome.Models;
    using KeepHome.Web.Areas.Admin.ViewModels.ChildCategory;
    using KeepHome.Web.Areas.Admin.ViewModels.Products;
    using KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Input;
    using KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Output;
    using KeepHome.Web.ViewModels.ShoppingBag;
    using KeepHome.Web.ViewModels.ChildCategories;
    using KeepHome.Web.ViewModels.Products;
    using KeepHome.Web.ViewModels.Address;
    using KeepHome.Web.Areas.Blog.ViewModels.BlogComment.Output;

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

            this.CreateMap<BlogPost, BlogPost>();
            this.CreateMap<BlogPost, BlogPostViewModel>();
            this.CreateMap<BlogPost, BlogPostDetailsViewModel>();
            this.CreateMap<BlogPost, BlogPostEditInputModel>();

            this.CreateMap<BlogComment, BlogCommentViewModel>();
        }
    }
}