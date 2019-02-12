namespace KeepHome.Services.Contracts
{
    using KeepHome.Models;

    using System.Collections.Generic;

    public interface IAddressesService
    {
        Address CreateAddress(string country, string town, string street, string otherDetails);
        void AddAddressToUser(string username, Address address);
        IEnumerable<Address> GetAllAddressByUser(string username);
    }
}