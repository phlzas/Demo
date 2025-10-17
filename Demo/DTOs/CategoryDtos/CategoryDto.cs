using System.ComponentModel.DataAnnotations;
using Demo.DTOs.ArtPieceDtos;

namespace Demo.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfArtPieces { get; set; }

        public List<ArtPieceDto> ArtPieces { get; set; } = new List<ArtPieceDto>();
    }
}
