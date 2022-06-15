namespace BlazorEComerce.Client.Pages
{
    public partial class Login
    {
        private string errorMessage = string.Empty;
        private UserLogin user = new UserLogin();
        private async Task HandleLogin()
        {
            var result = await AuthService.Login(user);
            if (result.Success)
            {
                errorMessage = string.Empty;
                await LocalStorage.SetItemAsync("authToken", result.Data);

                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                NavigationManager.NavigateTo("");
            }
            else
            {
                errorMessage = result.Message;
            }
        }
    }
}
