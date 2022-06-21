namespace BlazorEComerce.Client.Shared
{
    public partial class UserButton
    {
        private bool showUserMenu = false;
        private string UserMenuCssClass => showUserMenu ? "show-menu" : null;

        private void ToggleUserMenu()
        {
            showUserMenu = !showUserMenu;
        }

        private async Task HideUserMenu()
        {
            await Task.Delay(200);
            showUserMenu = false;
        }

        private async Task Logout()
        {
            await LocalStorage.RemoveItemAsync("authToken");
            await CartService.GetCartItemsCount();
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("");
        }

    }
}
