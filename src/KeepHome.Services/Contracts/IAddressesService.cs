namespace KeepHome.Services.Contracts
{
    using KeepHome.Models;

    using System.Collections.Generic;

    public interface IAddressesService
    {
        Address CreateAddress(string deliveryAddress, string city, string addressDetails);
        void AddAddressToUser(string username, Address address);
        IEnumerable<Address> GetAllAddressByUser(string username);
    }
}