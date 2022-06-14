namespace BlazorEComerce.Client.Pages
{
    public partial class Register
    {
        UserRegister user = new UserRegister();

        string errorMessage = string.Empty;

        async Task HandleRegistration()
        {
            var result = await AuthService.Register(user);
            if (!result.Success)
            {
                errorMessage = result.Message;
            }
            else
            {
                errorMessage = string.Empty;
            }
        }
    }
}
