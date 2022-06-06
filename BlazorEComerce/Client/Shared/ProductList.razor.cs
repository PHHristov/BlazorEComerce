
namespace BlazorEComerce.Client.Shared
{
    public partial class ProductList
    {
        private static List<Product> Products = new();

        protected override async Task OnInitializedAsync()
        {
            await productService.GetProducts();
        }

    }
}
