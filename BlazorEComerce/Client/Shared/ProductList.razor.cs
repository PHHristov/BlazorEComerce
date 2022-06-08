
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
        private string GetPriceTag(Product product)
        {
            var variants = product.Variants;
            if (variants.Count == 0)
            {
                return string.Empty;
            }
            else if (variants.Count == 1)
            {
                return $"{variants[0].Price}";
            }

            decimal minPrice = variants.Min(v => v.Price);
            return $"Starting at {minPrice}";
        }

    }
}
