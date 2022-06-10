namespace BlazorEComerce.Client.Shared
{
    public partial class FeaturedProducts
    {
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
