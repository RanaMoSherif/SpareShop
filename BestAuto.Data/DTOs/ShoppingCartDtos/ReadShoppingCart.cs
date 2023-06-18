namespace BestAuto.Data.DTOs.ShoppingCartDtos
{
    public class ReadShoppingCartDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string ImgPath { get; set; } = string.Empty;
        public string ModelNumber { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Count { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? UserId { get; set; }
    }
}