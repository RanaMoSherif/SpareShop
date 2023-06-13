

using SpareShop.Data.Repository.BrandRepo;
using SpareShop.Data.Repository.CategoryRepo;
using SpareShop.Data.Repository.OrderHeaderRepo;
using SpareShop.Data.Repository.OrderRepo;
using SpareShop.Data.Repository.ProductRepo;
using SpareShop.Data.Repository.ReviewRepo;
using SpareShop.Data.Repository.ShoppingCartRepo;

namespace SpareShop.Data.Repository._0_UnitOfWork
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