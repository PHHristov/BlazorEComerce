namespace BlazorEComerce.Client.Pages
{
    public partial class Register
    {
        UserRegister user = new UserRegister();

        string message = string.Empty;
        string messageCssClass = string.Empty;

        async Task HandleRegistration()
        {
            var result = await AuthService.Register(user);
            message = result.Message;
            if (!result.Success)
            {
                messageCssClass = "text-danger";
            }
            else
            {
                messageCssClass = "text-success";
            }
        }
    }
}
