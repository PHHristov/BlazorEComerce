namespace BlazorEComerce.Client.Pages
{
    public partial class OrderDetails
    {
        [Parameter]
        public int OrderId { get; set; }
        OrderDetailsResponseDTO order = null;

        protected override async Task OnInitializedAsync()
        {
            order = await OrderService.GetOrderDetails(OrderId);
        }
    
    }
}
