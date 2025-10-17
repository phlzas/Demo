using System.ComponentModel.DataAnnotations;

namespace Demo.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; } 

        //

        public List<ArtPiece> ArtPieces { get; set; }

        public LoyaltyCard LoyaltyCard { get; set; }
    }
}
