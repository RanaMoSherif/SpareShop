

using SpareShop.Data.Repository._1_MainRepo;
using SpareShop.Domain.Entities;

namespace SpareShop.Data.Repository.ShoppingCartRepo
{
    public class ShoppingCartRepo : Repo<ShoppingCart, Guid>, IShoppingCartRepo
    {
        //private readonly ApplicationDbContext _context;

        public ShoppingCartRepo(ApplicationDbContext context) : base(context)
        {
            //_context = context;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }

        public int ChangeCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count = count;
            return shoppingCart.Count;
        }
    }
}