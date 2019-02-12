namespace KeepHome.Services
{
    using KeepHome.Data;
    using KeepHome.Models;
    using KeepHome.Services.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class AddressesService : IAddressesService
    {
        private readonly KeepHomeContext dbContext;
        private readonly IUserService userService;

        public AddressesService(KeepHomeContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public void AddAddressToUser(string username, Address address)
        {
            var user = this.userService.GetUserByUsername(username);
            user.Addresses.Add(address);

            this.dbContext.SaveChanges();
        }

        public Address CreateAddress(string country, string town, string street, string otherDetails)
        {
            var address = new Address()
            {
                Country = country,
                Town = town,
                Street = street,
                OtherDetails = otherDetails
            };

            this.dbContext.Addresses.Add(address);
            this.dbContext.SaveChanges();

            return address;
        }

        public IEnumerable<Address> GetAllAddressByUser(string username)
            => this.dbContext.Addresses.Where(x => x.User.UserName == username).ToList();
    }
}