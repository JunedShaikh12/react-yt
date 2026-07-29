namespace ModelBinding.Models
{
    public class PModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
