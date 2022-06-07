namespace BlazorEComerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var result = await _context.Categories.ToListAsync();

            return new ServiceResponse<List<Category>>
            {
                Data = result
            };
        }
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
