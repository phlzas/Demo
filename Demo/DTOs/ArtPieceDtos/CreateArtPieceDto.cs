using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Demo.DTOs.ArtPieceDtos
{
    public class CreateArtPieceDto
    {

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        [Required, Range(1, int.MaxValue), Precision(8, 3)]
        public decimal Price { get; set; }

        public int CustomerId { get; set; }
        public List<int> CategoriesIds { get; set; } = new List<int>();
    }
}
