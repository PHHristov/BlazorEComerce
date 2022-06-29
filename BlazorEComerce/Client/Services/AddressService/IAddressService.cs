namespace BlazorEComerce.Client.Services.AddressService
{
    public interface IAddressService
    {
        Task<Address> GetAddressAsync();
        Task<Address> AddOrUpdateAddress(Address address);
    }
}
