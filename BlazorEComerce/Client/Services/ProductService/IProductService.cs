namespace BlazorEComerce.Client.Services
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetProducts();
    }
}
