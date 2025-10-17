using Demo.Data;
using Demo.Data.Models;
using Demo.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories.CustomerRepository
{
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
    {
        public CustomerRepo(MyAppDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> GetAllCustomersWithInformation()
        {
            return await _context.Customers
                .Include(c => c.ArtPieces)
                .Include(c => c.LoyaltyCard)
                .ToListAsync();
        }
    }
}
