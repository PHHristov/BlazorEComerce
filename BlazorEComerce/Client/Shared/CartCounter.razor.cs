namespace BlazorEComerce.Client.Shared
{
    public partial class CartCounter
    {
        private int GetCartItemsCount()
        {
            var count = LocalStorage.GetItem<int>("cartItemsCount");
            return count;
        }

        protected override void OnInitialized()
        {
            CartService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CartService.OnChange -= StateHasChanged;     
        }
    }
}
