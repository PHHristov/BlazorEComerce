using Stripe.Checkout;

namespace BlazorEComerce.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSesions();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);
    }
}
