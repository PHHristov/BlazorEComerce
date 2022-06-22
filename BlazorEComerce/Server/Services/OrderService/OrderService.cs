using System.Security.Claims;

namespace BlazorEComerce.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        public OrderService(ApplicationDbContext context, ICartService cartService, IAuthService authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<OrderOverviewRepopnseDTO>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewRepopnseDTO>>();
            var orders = await _context.Orders
                                       .Include(o => o.OrderItems)
                                       .ThenInclude(oi => oi.Product)
                                       .Where(o => o.UserId == _authService.GetUserId())
                                       .OrderByDescending(o => o.OrderDate)
                                       .ToListAsync();

            var orderResponse = new List<OrderOverviewRepopnseDTO>();
            orders.ForEach(order => orderResponse.Add(new OrderOverviewRepopnseDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Product = order.OrderItems.Count > 1 ?
                          $"{order.OrderItems.First().Product.Title} and " +
                          $"{order.OrderItems.Count - 1} more .." :
                          order.OrderItems.First().Product.Title,
                ProductImageUrl = order.OrderItems.First().Product.ImageUrl
            }));

            response.Data = orderResponse;
            return response;

        }

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            decimal totalPrice = 0;
            products.ForEach(product => totalPrice += (product.Price * product.Quantity));

            var orderItems = new List<OrderItem>();

            products.ForEach(product => orderItems.Add(new OrderItem
            {
                ProductId = product.ProductId,
                ProductTypeId = product.ProductTypeId,
                Quantity = product.Quantity,
                TotalPrice = product.Price * product.Quantity,
            }));

            var order = new Order
            {
                UserId = _authService.GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(_context.CartItems
                                                   .Where(ci => ci.UserId == _authService.GetUserId()));
            await _context.SaveChangesAsync();


            return new ServiceResponse<bool>
            {
                Data = true
            };
        }

    }
}
