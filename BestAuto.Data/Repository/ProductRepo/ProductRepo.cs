
using BestAuto.Data.Repository._1_MainRepo;
using BestAuto.Domain.Entities;

namespace BestAuto.Data.Repository.ProductRepo
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