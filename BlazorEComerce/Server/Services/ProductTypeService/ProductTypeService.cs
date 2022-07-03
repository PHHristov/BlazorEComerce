namespace BlazorEComerce.Server.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductType>>> GetProductTypes()
        {
            var products = await _context.ProductTypes.ToListAsync();
            return new ServiceResponse<List<ProductType>> { Data = products };
        }
    }
}
