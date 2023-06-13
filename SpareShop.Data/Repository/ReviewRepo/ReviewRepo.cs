

using SpareShop.Data.Repository._1_MainRepo;
using SpareShop.Domain.Entities;

namespace SpareShop.Data.Repository.ReviewRepo
{
    public class ReviewRepo : Repo<Review, Guid>, IReviewRepo
    {
        //private readonly ApplicationDbContext _context;

        public ReviewRepo(ApplicationDbContext context) : base(context)
        {
            //_context = context;
        }
    }
}