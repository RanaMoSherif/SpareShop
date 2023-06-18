

using BestAuto.Data.Repository.BrandRepo;
using BestAuto.Data.Repository.CategoryRepo;
using BestAuto.Data.Repository.OrderHeaderRepo;
using BestAuto.Data.Repository.OrderRepo;
using BestAuto.Data.Repository.ProductRepo;
using BestAuto.Data.Repository.ReviewRepo;
using BestAuto.Data.Repository.ShoppingCartRepo;

namespace BestAuto.Data.Repository._0_UnitOfWork
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