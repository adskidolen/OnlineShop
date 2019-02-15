namespace KeepHome.Web.Areas.Blog.Controllers.Base
{
    using KeepHome.Common;
    using KeepHome.Web.Controllers.Base;
    
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.BlogAreaName)]
    public abstract class BaseBlogController : BaseController
    {
        protected BaseBlogController() { }
    }
}