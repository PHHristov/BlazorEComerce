namespace BlazorEComerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<Product>>> GetAdminProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                                     .Where(p => !p.Deleted)
                                     .Include(p => p.Variants.Where(v => v.Visible))
                                     .ThenInclude(v => v.ProductType)
                                     .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                    .Where(p => p.Featured && p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                product = await _context.Products
                                        .Include(p => p.Variants.Where(v => !v.Deleted))
                                        .ThenInclude(v => v.ProductType)
                                        .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            else
            {


                product = await _context.Products
                                           .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                                           .ThenInclude(v => v.ProductType)
                                           .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted && p.Visible);
            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this problem does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                                     .Where(p => p.Visible && !p.Deleted)
                                     .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                                     .ToListAsync()            
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                                     .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()) && p.Visible && !p.Deleted)
                                     .Include(p => p.Variants)
                                     .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }
                if (product.Description != null)
                {
                    var punctuation = product.Description
                                             .Where(char.IsPunctuation)
                                             .Distinct()
                                             .ToArray();
                    var words = product.Description.Split()
                                        .Select(s => s.Trim(punctuation));
                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word.ToLower()))
                        {
                            result.Add(word.ToLower());
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result};
        }

        public async Task<ServiceResponse<ProductSearchResultDTO>> SearchProduct(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
            var products = await _context.Products
                                                 .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                                                 ||
                                                 p.Description.ToLower().Contains(searchText.ToLower()) && p.Visible && !p.Deleted)
                                                 .Include(p => p.Variants)
                                                 .Skip((page - 1) * (int)pageResults)
                                                 .Take((int)pageResults)
                                                 .ToListAsync();



            var response = new ServiceResponse<ProductSearchResultDTO>
            {
                Data = new ProductSearchResultDTO
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };
            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                                                 .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                                                 ||
                                                 p.Description.ToLower().Contains(searchText.ToLower()) && p.Visible && !p.Deleted)
                                                 .Include(p => p.Variants)
                                                 .ToListAsync();
        }
    }
}
