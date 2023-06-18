

using BestAuto.Data.Repository._1_MainRepo;
using BestAuto.Domain.Entities;

namespace BestAuto.Data.Repository.CategoryRepo
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