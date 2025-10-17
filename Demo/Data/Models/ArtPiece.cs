using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Models
{
    public class ArtPiece
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        [Required, Range(1, int.MaxValue), Precision(8, 3)]
        public decimal Price { get; set; }

        // Nav

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Category> Categories { get; set; }
    }
}
