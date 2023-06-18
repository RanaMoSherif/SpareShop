

using BestAuto.Data.Repository._1_MainRepo;
using BestAuto.Domain.Entities;

namespace BestAuto.Data.Repository.ReviewRepo
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