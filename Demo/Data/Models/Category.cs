using System.ComponentModel.DataAnnotations;

namespace Demo.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required] // Unique
        public string Name { get; set; }

        // 

        public List<ArtPiece> ArtPieces { get; set; }
    }
}
