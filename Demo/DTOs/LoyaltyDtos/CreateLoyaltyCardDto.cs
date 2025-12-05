using System.ComponentModel.DataAnnotations;

namespace Demo.DTOs
{
    public class CreateLoyaltyCardDto
    {
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
