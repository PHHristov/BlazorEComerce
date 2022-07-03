using BlazorECommerce.Shared;
using Microsoft.JSInterop;

namespace BlazorEComerce.Client.Pages.Admin
{
    public partial class EditProduct
    {
        [Parameter]
        public int Id { get; set; }
        Product product = new Product();
        bool loading = true;
        string btnText = "";
        string msg = "Loading...";

        protected override async Task OnInitializedAsync()
        {
            await ProductTypeService.GetProductTypes();
            await CategoryService.GetAdminCategories();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id == 0)
            {
                product = new Product { IsNew = true };
                btnText = "Create Product";
            }
            else
            {
                Product dbProduct = (await ProductService.GetProduct(Id)).Data;
                if (dbProduct == null)
                {
                    msg = $"Product with '{Id}' does not exist.";
                    return;
                }
                product = dbProduct;
                product.Editing = true;
                btnText = "UpdateProduct";
            }
            loading = false;

        }

        void RemoveVariant(int productTypeId)
        {
            var variant = product.Variants.Find(v => v.ProductTypeId == productTypeId);
            if (variant == null)
            {
                return;
            }
            if (variant.IsNew) 
            {
                product.Variants.Remove(variant);
            }
            else
            {
                variant.Deleted = true;
            }
        }

        void AddVariant()
        {
            product.Variants.Add(new ProductVariant { IsNew = true, ProductId = product.Id});
        }
        async void AddOrUpdateProduct()
        {
            if (product.IsNew)
            {
                var result = await ProductService.CreateProduct(product);
                NavigationManager.NavigateTo($"admin/product/{result.Id}");
            }
            else
            {
                product.IsNew = false;
                product = await ProductService.UpdateProduct(product);
                NavigationManager.NavigateTo($"admin/product/{product.Id}", true);
            }
        }

        async void DeleteProduct()
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm",
                $"Do you really want to delete '{product.Title}'?");
            if (confirmed)
            {
                await ProductService.DeleteProduct(product);
                NavigationManager.NavigateTo("admin/products");
            }
        }
    }

}
