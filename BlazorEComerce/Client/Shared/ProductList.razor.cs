
namespace BlazorEComerce.Client.Shared
{
    public partial class ProductList
    {
        private static List<Product> Products = new();

        protected override void OnInitialized()
        {
            ProductService.ProductsChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ProductService.ProductsChanged -= StateHasChanged;
        }

    }
}
