using Stripe.Checkout;

namespace BlazorEComerce.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSesions();
    }
}
