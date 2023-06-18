

using BestAuto.Data.Repository.BrandRepo;
using BestAuto.Data.Repository.CategoryRepo;
using BestAuto.Data.Repository.OrderHeaderRepo;
using BestAuto.Data.Repository.OrderRepo;
using BestAuto.Data.Repository.ProductRepo;
using BestAuto.Data.Repository.ReviewRepo;
using BestAuto.Data.Repository.ShoppingCartRepo;

namespace BestAuto.Data.Repository._0_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepo Product { get; private set; }
        public IBrandRepo Brand { get; private set; }
        public ICategoryRepo Category { get; private set; }
        public IReviewRepo Review { get; private set; }
        public IShoppingCartRepo ShoppingCart { get; private set; }
        public IOrderHeaderRepo OrderHeader { get; private set; }
        public IOrderForDetailRepo OrderForDetail { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Product = new ProductRepo.ProductRepo(_context);
            Brand = new BrandRepo.BrandRepo(_context);
            Category = new CategoryRepo.CategoryRepo(_context);
            Review = new ReviewRepo.ReviewRepo(_context);
            ShoppingCart = new ShoppingCartRepo.ShoppingCartRepo(_context);
            OrderHeader = new OrderHeaderRepo.OrderHeaderRepo(_context);
            OrderForDetail = new OrderForDetailRepo(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}