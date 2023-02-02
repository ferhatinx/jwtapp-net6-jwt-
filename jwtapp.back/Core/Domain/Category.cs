namespace jwtapp.back.Core.Domain
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public int Id { get; set; }
        public string? Definition { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}