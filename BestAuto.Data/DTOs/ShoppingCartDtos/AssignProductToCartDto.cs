﻿namespace BestAuto.Data.DTOs.ShoppingCartDtos;

    public class AssignProductToCartDto
    {
    public Guid ProductId { get; set; }

    public int? Count { get; set; } = 1;

    public Guid? UserId { get; set; }
}
