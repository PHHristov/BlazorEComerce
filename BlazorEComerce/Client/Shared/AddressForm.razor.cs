namespace BlazorEComerce.Client.Shared
{
    public partial class AddressForm
    {
        Address address = null;
        bool editAddress = false;

        protected override async Task OnInitializedAsync()
        {
            address = await AddressService.GetAddress();
        }

        private async Task SubmitAddress()
        {
            editAddress = false;
            address = await AddressService.AddOrUpdateAddress(address);
        }


        private void InitAddress()
        {
            address = new Address();
            editAddress = true;
        }

        private void EditAddress()
        {
            editAddress = true;
        }
    }
}
