namespace jwtapp.back.Core.Domain
{
    public class Product
    {
        public Product()
        {
            this.Category = new Category();
        }
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}