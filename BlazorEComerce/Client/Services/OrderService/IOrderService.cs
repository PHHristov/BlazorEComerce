namespace BlazorEComerce.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task PlaceOrder();
        Task<List<OrderOverviewRepopnseDTO>> GetOrders();
    }
}
