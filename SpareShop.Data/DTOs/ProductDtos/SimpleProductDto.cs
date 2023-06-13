namespace SpareShop.Data.DTOs.ProductDtos;

    public class SimpleProductDto : ReadDto
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImgPath { get; set; } = string.Empty;
    public double Price { get; set; } = 1;
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
}
