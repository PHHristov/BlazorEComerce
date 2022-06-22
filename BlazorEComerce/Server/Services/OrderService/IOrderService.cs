namespace BlazorEComerce.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder();
        Task<ServiceResponse<List<OrderOverviewRepopnseDTO>>> GetOrders();
    }
}
