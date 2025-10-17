using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Demo.DTOs.CustomerDtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal TotalSpending { get; set; }
        public Card Card { get; set; }
        public List<CustomArtPieces> CustomArtPieces { get; set; } = new List<CustomArtPieces>();
    }

    public class CustomArtPieces
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class Card
    {
        public int Id { get; set; }

        [Required] // Unique
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
