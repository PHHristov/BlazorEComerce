using Microsoft.AspNetCore.Components;

namespace BlazorEComerce.Client.Pages
{
    public partial class ProductDetails
    {
        private Product? product = null;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            product = productService.Products.Find( p => p.Id == Id );
        }
    }
}

