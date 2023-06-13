namespace SpareShop.Data.DTOs.ProductDtos;

    public class ReadProductDto:ReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacture { get; set; } = string.Empty;
        public string ModelNumber { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string ImgPath { get; set; } = string.Empty;
        public double Price { get; set; } = 1;
        public int Count { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
}
