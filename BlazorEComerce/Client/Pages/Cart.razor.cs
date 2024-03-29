﻿namespace BlazorEComerce.Client.Pages
{
    public partial class Cart
    {
        List<CartProductResponseDTO> cartProducts = null;
        string message = "Loading cart ...";
        bool isAuthernticated = false;

        protected override async Task OnInitializedAsync()
        {
            isAuthernticated = await AuthService.IsUserAuthenticated();
            await LoadCart();
        }

        private async Task LoadCart()
        {
            await CartService.GetCartItemsCount();
            cartProducts = await CartService.GetCartProducts();

            if (cartProducts == null || cartProducts.Count == 0 )
            {
                message = "Your cart is empty";
            }
        }

        private async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            await CartService.RemoveProductFromCart(productId, productTypeId);
            await LoadCart();
        }

        private async Task UpdateQuantity(ChangeEventArgs e, CartProductResponseDTO prodcut)
        {
            prodcut.Quantity = int.Parse(e.Value.ToString());
            if (prodcut.Quantity < 1)
            {
                prodcut.Quantity = 1;
            }
            await CartService.UpdateQuantity(prodcut);
        }

        private async Task PlaceOrder()
        {
            string url = await OrderService.PlaceOrder();
            NavigationManager.NavigateTo(url);
        }
    }

}
