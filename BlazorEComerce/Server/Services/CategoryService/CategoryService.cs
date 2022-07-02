namespace BlazorEComerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var result = await _context.Categories
                                       .Where(c => !c.Deleted && c.Visible).ToListAsync();

            return new ServiceResponse<List<Category>>
            {
                Data = result
            };
        }

        public async Task<ServiceResponse<List<Category>>> GetAdminCategories()
        {
            var result = await _context.Categories
                                    .Where(c => !c.Deleted ).ToListAsync();

            return new ServiceResponse<List<Category>>
            {
                Data = result
            };
        }

        public async Task<ServiceResponse<List<Category>>> AddCategories(Category category)
        {
            category.Editing = category.IsNew = false;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> UpdateCategory(Category category)
        {
            var dbCategory = await GetCategoryById(category.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }
            dbCategory.Name = category.Name;
            dbCategory.Url = category.Url;
            dbCategory.Visible = category.Visible;

            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> DeleteCategory(int id)
        {
            Category category = await GetCategoryById(id);
            if (category == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }
            category.Deleted = true;
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        private async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
