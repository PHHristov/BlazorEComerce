namespace BlazorEComerce.Client.Pages
{
    public partial class Register
    {
        UserRegister user = new UserRegister();

        void HandleRegistration()
        {
            Console.WriteLine($"Register the User with Email {user.Email}");
        }
    }
}
