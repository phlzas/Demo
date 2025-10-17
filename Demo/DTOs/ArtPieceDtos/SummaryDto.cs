using System.ComponentModel.DataAnnotations;

namespace Demo.DTOs.ArtPieceDtos
{
    public class SummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Total_Revenue { get; set; }

        public List<SummaryArts> ArtPieces { get; set; }
    }

    public class SummaryArts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public CusLoayltyDto Customer { get; set; }
    }

    public class CusLoayltyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CustomLoyal loyalityCard { get; set; }
    }

    public class CustomLoyal
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}

