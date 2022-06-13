namespace BlazorEComerce.Client.Shared
{
    public partial class CartCounter
    {
        private int GetCartItemsCount()
        {
            var cart = LocalStorage.GetItem<List<CartItem>>("cart");
            return cart.Count != null? cart.Count : 0;
        }

        protected override void OnInitialized()
        {
            CartService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CartService.OnChange -= StateHasChanged;     
        }
    }
}
