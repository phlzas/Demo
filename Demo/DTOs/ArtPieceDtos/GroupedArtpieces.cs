namespace Demo.DTOs.ArtPieceDtos
{
    public class GroupedArtpieces
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int No_Of_Pieces { get; set; }
        public decimal AveragePrice { get; set; }
        public List<CustomArt> ArtPieces { get; set; } 
    }

    public class CustomArt
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
