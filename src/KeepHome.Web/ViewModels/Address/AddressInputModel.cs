namespace KeepHome.Web.ViewModels.Address
{
    using System.ComponentModel.DataAnnotations;

    public class AddressInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string OtherDetails { get; set; }
    }
}