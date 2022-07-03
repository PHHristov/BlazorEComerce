namespace BlazorEComerce.Client.Pages.Admin
{
    public partial class ProductTypes
    {
        ProductType editingProductType = null;

        protected override async Task OnInitializedAsync()
        {
            await ProductTypeService.GetProductTypes();
        }

        private void EditProductType(ProductType productType)
        {
            productType.Editing = true;
            editingProductType = productType;

        }

        private void CreateNewProductType()
        {

        }

        private void UpdateProuctType()
        {

        }
    }
}
