namespace KeepHome.Web.ViewModels.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using KeepHome.Models.Enums;
    using KeepHome.Web.ViewModels.Address;

    public class CheckoutInputModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public PaymentType PaymentType { get; set; }
        public int? DeliveryAddressId { get; set; }

        public IEnumerable<AddressInputModel> Addresses { get; set; }
        public AddressInputModel Address { get; set; }
    }
}