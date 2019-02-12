namespace KeepHome.Web.ViewModels.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using KeepHome.Models.Enums;
    using KeepHome.Web.ViewModels.Address;

    public class OrderInputModel
    {
        [Display(Name = "Адрес на получаване")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public int? DeliveryAddressId { get; set; }

        [Display(Name = "Име на получателя")]
        [Required(ErrorMessage = "Моля въведете \"{0}\".")]
        public string FullName { get; set; }

        [Display(Name = "GSM номер")]
        [Required(ErrorMessage = "Моля въведете \"{0}\".")]
        public string PhoneNumber { get; set; }

        public PaymentType PaymentType { get; set; }

        public IList<AddressInputModel> Addresses { get; set; }
        public AddressInputModel Address { get; set; }
    }
}