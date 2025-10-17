using System.ComponentModel.DataAnnotations;

namespace Demo.DTOs.ArtPieceDtos
{
    public class ArtPieceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public CustomCustomer Customer { get; set; }
        public List<CustomCategory> Categories { get; set; }
    }

    public class CustomCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class CustomCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
