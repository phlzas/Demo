using Demo.Data.Models;
using Demo.Repositories.GenericRepository;

namespace Demo.Repositories.ArtPieceRepository
{
    public interface IArtPieceRepo : IGenericRepo<ArtPiece>
    {
        Task<IEnumerable<ArtPiece>> GetAllArtPiecesAsync();

        Task<IEnumerable<Customer>> GetDistinctCustomers();

        Task<IEnumerable<ArtPiece>> GetAllArtPiecesCategorySpendingAsync();
    }
}
