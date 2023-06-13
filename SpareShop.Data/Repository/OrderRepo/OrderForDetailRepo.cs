
using SpareShop.Data.Repository._1_MainRepo;
using SpareShop.Domain.Entities;

namespace SpareShop.Data.Repository.OrderRepo
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