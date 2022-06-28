namespace BlazorEComerce.Client.Pages
{
    public partial class Orders
    {
        List<OrderOverviewResponseDTO> orders = null;

        protected override async Task OnInitializedAsync()
        {
            orders = await OrderService.GetOrders();
        }
    }
}
