
using BestAuto.Data.Repository._1_MainRepo;
using BestAuto.Domain.Entities;

namespace BestAuto.Data.Repository.OrderRepo
{
    public class OrderForDetailRepo : Repo<OrderDetail, Guid>, IOrderForDetailRepo
    {
        //private readonly ApplicationDbContext _context;

        public OrderForDetailRepo(ApplicationDbContext context) : base(context)
        {
            //_context = context;
        }
    }
}