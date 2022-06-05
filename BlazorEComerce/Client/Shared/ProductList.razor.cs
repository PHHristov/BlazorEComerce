


namespace BlazorEComerce.Client.Shared
{
    public partial class ProductList
    {
        private static List<Product> Products = new();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetFromJsonAsync<List<Product>>("api/Product");
            if (result != null)
            {
                Products = result;
            }
        }

    }
}
