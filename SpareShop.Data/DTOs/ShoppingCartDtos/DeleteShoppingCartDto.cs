namespace SpareShop.Data.DTOs.ShoppingCartDtos
{
    public class DeleteShoppingCartDto
    {
        public Guid ProductId { get; set; }

        public Guid? UserId { get; set; }
    }
}