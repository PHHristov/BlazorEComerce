using Microsoft.AspNetCore.Components;

namespace BlazorEComerce.Client.Pages
{
    public partial class ProductDetails
    {
        private Product? product = null;
        private string message = string.Empty;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            message = "Loading Product";
            var result  = await ProductService.GetProduct(Id);

            if (!result.Success)
            {
                message = result.Message;
            }
            else
            {
                product = result.Data;
            }
        }
    }
}

