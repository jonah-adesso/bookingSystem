
namespace api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int QuantityInStock { get; set; }
        public string PublicId { get; set; }
    }
}