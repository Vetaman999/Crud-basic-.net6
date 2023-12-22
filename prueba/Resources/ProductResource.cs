namespace prueba.Resources
{
    public class ProductResource
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public long Stock { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
