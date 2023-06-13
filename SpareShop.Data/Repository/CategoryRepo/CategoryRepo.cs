

using SpareShop.Data.Repository._1_MainRepo;
using SpareShop.Domain.Entities;

namespace SpareShop.Data.Repository.CategoryRepo
{
    public class CategoryRepo : Repo<Category, int>, ICategoryRepo
    {
        //private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
            //_context = context;
        }
    }
}