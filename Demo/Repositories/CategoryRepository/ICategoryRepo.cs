using Demo.Data.Models;
using Demo.Repositories.GenericRepository;

namespace Demo.Repositories.CategoryRepository
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        Task<IEnumerable<Category>> GetAllCateogriesAsync();

        Task<Category?> GetCategoryById(int id);

        Task<IEnumerable<Category>> GetAllCategoriesSummaryAsync();
    }
}
