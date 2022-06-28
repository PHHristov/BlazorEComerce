namespace BlazorEComerce.Client.Pages
{
    public partial class OrderSuccess
    {
        protected override async Task OnInitializedAsync()
        {
            await CartService.GetCartItemsCount();
        }
    }
}
