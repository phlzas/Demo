using Demo.Data.Models;
using Demo.Repositories.GenericRepository;

namespace Demo.Repositories
{
    public interface ILoyalityCardRepo : IGenericRepo<LoyaltyCard>
    {
        Task<IEnumerable<LoyaltyCard>> GetAllLoyaltyCardsAsync();
    }
}
