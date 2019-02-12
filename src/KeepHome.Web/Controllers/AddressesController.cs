namespace KeepHome.Web.Controllers
{
    using KeepHome.Services.Contracts;
    using KeepHome.Web.Controllers.Base;
    using KeepHome.Web.ViewModels.Address;

    using Microsoft.AspNetCore.Mvc;

    public class AddressesController : BaseController
    {
        private readonly IAddressesService addressesService;

        public AddressesController(IAddressesService addressesService)
        {
            this.addressesService = addressesService;
        }

        public IActionResult Add(AddressInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Checkout", "Orders");
            }

            var adress = this.addressesService.CreateAddress(model.Country, model.Town, model.Street, model.OtherDetails);

            this.addressesService.AddAddressToUser(this.User.Identity.Name, adress);

            return this.RedirectToAction("Checkout", "Orders");
        }
    }
}