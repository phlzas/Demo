using Demo.Data;
using Demo.Data.Models;
using Demo.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class LoyalityCardRepo : GenericRepo<LoyaltyCard>, ILoyalityCardRepo
    {
        public LoyalityCardRepo(MyAppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LoyaltyCard>> GetAllLoyaltyCardsAsync()
        {
            return await _context.LoyaltyCards
                .Include(l => l.Customer)
                .Where(l => l.Balance > 0)
                .ToListAsync();
        }
    }
}
