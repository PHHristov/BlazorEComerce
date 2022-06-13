namespace BlazorEComerce.Client.Pages
{
    public partial class Cart
    {
        List<CartProductResponseDTO> cartProducts = null;
        string message = "Loading cart ...";

        protected override async Task OnInitializedAsync()
        {
            await LoadCart();
        }

        private async Task LoadCart()
        {
            if ((await CartService.GetCartItems()).Count == 0)
            {
                message = "Your cart is empty";
                cartProducts = new List<CartProductResponseDTO>();
            }
            else
            {
                cartProducts = await CartService.GetCartProducts();
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

    }

}
