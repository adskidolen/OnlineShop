namespace KeepHome.Web.Areas.Admin.Controllers.Base
{
    using KeepHome.Common;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdminRoleName)]
    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    public abstract class AdminBaseController : Controller
    {
        protected AdminBaseController() { }
    }
}