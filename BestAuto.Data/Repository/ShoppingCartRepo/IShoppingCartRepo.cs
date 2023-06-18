

using BestAuto.Data.Repository._1_MainRepo;
using BestAuto.Domain.Entities;

namespace BestAuto.Data.Repository.ShoppingCartRepo
{
    public interface IShoppingCartRepo : IRepo<ShoppingCart, Guid>
    {
        int IncrementCount(ShoppingCart shoppingCart, int count);

        int DecrementCount(ShoppingCart shoppingCart, int count);

        int ChangeCount(ShoppingCart shoppingCart, int count);
    }
}