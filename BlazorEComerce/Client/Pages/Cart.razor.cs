namespace BlazorEComerce.Client.Pages
{
    public partial class Cart
    {
        List<CartProductResponseDTO> cartProducts = null;
        string message = "Loading cart ...";

        protected override async Task OnInitializedAsync()
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

    }

}
