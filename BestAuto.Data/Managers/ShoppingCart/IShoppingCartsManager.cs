

using BestAuto.Data.DTOs.ShoppingCartDtos;

namespace BestAuto.Data.Managers.ShoppingCart;

public interface IShoppingCartsManager
{
    List<ReadShoppingCartDto> GetAll(string[]? include = null!);
    Task<UpdateShoppingCartDto> AssignProduct(AssignProductToCartDto dto);
    bool Delete(DeleteShoppingCartDto dto);
    bool IncrementCount(UpdateShoppingCartDto dto);
    bool DecrementCount(UpdateShoppingCartDto dto);
    bool ChangeCount(ChangeCountShoppingCartDto dto);

}