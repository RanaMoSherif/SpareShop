
using SpareShop.Data.Repository._1_MainRepo;
using SpareShop.Domain.Entities;

namespace SpareShop.Data.Repository.ProductRepo
{
    public class ProductRepo : Repo<Product, Guid>, IProductRepo
    {
        //private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            //_context = context;
        }
    }
}