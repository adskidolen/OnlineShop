using KeepHome.Models;
using KeepHome.Web.Areas.Admin.ViewModels.ChildCategory;
using KeepHome.Web.Areas.Admin.ViewModels.ParentCategory;

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
        }
    }
}