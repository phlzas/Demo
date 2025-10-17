using System.ComponentModel.DataAnnotations;

namespace Demo.Data.Models
{
    public class LoyaltyCard
    {
        public int Id { get; set; }

        [Required] // Unique
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }

        // 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
