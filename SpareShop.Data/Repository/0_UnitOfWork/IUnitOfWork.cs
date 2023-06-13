

using SpareShop.Data.Repository.BrandRepo;
using SpareShop.Data.Repository.CategoryRepo;
using SpareShop.Data.Repository.OrderHeaderRepo;
using SpareShop.Data.Repository.OrderRepo;
using SpareShop.Data.Repository.ProductRepo;
using SpareShop.Data.Repository.ReviewRepo;
using SpareShop.Data.Repository.ShoppingCartRepo;

namespace SpareShop.Data.Repository._0_UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepo Product { get; }
        IBrandRepo Brand { get; }
        ICategoryRepo Category { get; }
        IReviewRepo Review { get; }
        IShoppingCartRepo ShoppingCart { get; }
        IOrderHeaderRepo OrderHeader { get; }
        IOrderForDetailRepo OrderForDetail { get; }

        int Save();
    }
}