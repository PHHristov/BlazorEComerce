namespace BlazorEComerce.Client.Pages.Admin
{
    public partial class Products
    {
        protected override async Task OnInitializedAsync()
        {
            await ProductService.GetAdminProducts();
        }

        void EditProduct(int productId)
        {

        }
    }
}
