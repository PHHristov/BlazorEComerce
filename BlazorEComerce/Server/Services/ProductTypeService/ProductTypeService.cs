namespace BlazorEComerce.Server.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductType>>> AddProductType(ProductType productType)
        {
            productType.Editing = productType.IsNew = false;
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return await GetProductTypes();
        }

        public async Task<ServiceResponse<List<ProductType>>> GetProductTypes()
        {
            var products = await _context.ProductTypes.ToListAsync();
            return new ServiceResponse<List<ProductType>> { Data = products };
        }

        public async Task<ServiceResponse<List<ProductType>>> UpdateProductType(ProductType productType)
        {
            var dbProductType = await _context.ProductTypes.FindAsync(productType.Id);
            if (dbProductType == null)
            {
                return new ServiceResponse<List<ProductType>> { Success = false, Message = "ProductType not found!" };
            }

            dbProductType.Name = productType.Name;
            await _context.SaveChangesAsync();

            return await GetProductTypes();
        }
    }
}
