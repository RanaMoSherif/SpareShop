namespace SpareShop.Data.DTOs.ShoppingCartDtos
{
    public class UpdateShoppingCartDto
    {
        public Guid ProductId { get; set; }

        public Guid? UserId { get; set; }
    }
}