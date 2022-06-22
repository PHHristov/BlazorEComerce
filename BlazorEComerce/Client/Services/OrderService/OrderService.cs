namespace BlazorEComerce.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;


        public OrderService(NavigationManager navigationManager, AuthenticationStateProvider authStateProvider, HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _authStateProvider = authStateProvider;
            _httpClient = httpClient;
        }

        public async Task PlaceOrder()
        {
            if (await IsUserAuthenticated())
            {
                await _httpClient.PostAsync("api/order", null);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }

        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

    }
}
