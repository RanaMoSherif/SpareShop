

using BestAuto.Data.Repository._1_MainRepo;
using BestAuto.Domain.Entities;

namespace BestAuto.Data.Repository.BrandRepo
{
    public class BrandRepo : Repo<Brand, int>, IBrandRepo
    {
        //private readonly ApplicationDbContext _context;

        public BrandRepo(ApplicationDbContext context) : base(context)
        {
            //_context = context;
        }
    }
}