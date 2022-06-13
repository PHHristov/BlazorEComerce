

namespace BlazorEComerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        public CartService(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            cart.Add(cartItem);
            await _localStorageService.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            return cart;
        }

        public async Task<List<CartProductResponseDTO>> GetCartProducts()
        {
            var cartItems = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            var response = await _httpClient.PostAsJsonAsync("api/cart/products", cartItems);
            var cartProducts =
                await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponseDTO>>>();
            return cartProducts.Data;
        }
    }
}
