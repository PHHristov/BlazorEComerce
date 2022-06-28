using Stripe;
using Stripe.Checkout;

namespace BlazorEComerce.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;

        public PaymentService(IAuthService authService, IOrderService orderService, ICartService cartService)
        {
            StripeConfiguration.ApiKey = "sk_test_51LFa2jBzZOM9HtWshoFarLisnERwhOkt0tk0w7tKaIyqF1F1qQE5yDeUwCGP5q5mzMcEw9VHkwqm5TJfA8YPG9xx00n3zwDZ5p";
            _authService = authService;
            _orderService = orderService;
            _cartService = cartService;
        }

        public async Task<Session> CreateCheckoutSesions()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            products.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.imageUrl }
                    }
                },
                Quantity = product.Quantity
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7290/order-success",
                CancelUrl = "https://localhost:7290/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }
    }
}
