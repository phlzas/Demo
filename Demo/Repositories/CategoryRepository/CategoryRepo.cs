using Demo.Data;
using Demo.Data.Models;
using Demo.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories.CategoryRepository
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(MyAppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetAllCateogriesAsync()
        {
            return await _context.Categories
                .Include(c => c.ArtPieces)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories
                .Include(c => c.ArtPieces)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesSummaryAsync()
        {
            return await _context.Categories
                .Include(c => c.ArtPieces).ThenInclude(a => a.Customer).ThenInclude(c => c.LoyaltyCard)
                .ToListAsync();
        }
    }
}
