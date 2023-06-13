namespace SpareShop.Data.DTOs.BrandDtos;

    public class UpdateBrandDto : UpdateDto
    {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImgPath { get; set; } = string.Empty;
}
