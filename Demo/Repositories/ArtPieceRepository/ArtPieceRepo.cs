using Demo.Data;
using Demo.Data.Models;
using Demo.Repositories.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories.ArtPieceRepository
{
    public class ArtPieceRepo : GenericRepo<ArtPiece>, IArtPieceRepo
    {
        public ArtPieceRepo(MyAppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ArtPiece>> GetAllArtPiecesAsync()
        {
            return await _context.ArtPieces
                .Include(a => a.Customer)
                .Include(a => a.Categories)
                .ToListAsync();
        }

        public async Task<IEnumerable<ArtPiece>> GetAllArtPiecesCategorySpendingAsync()
        {
            return await _context.ArtPieces
                .Include(a => a.Customer).ThenInclude(c => c.LoyaltyCard)
                .Include(a => a.Categories)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetDistinctCustomers()
        {
            return await _context.ArtPieces
                .Select(c => c.Customer)
                .Distinct()
                .ToListAsync();
        }
    }
}
