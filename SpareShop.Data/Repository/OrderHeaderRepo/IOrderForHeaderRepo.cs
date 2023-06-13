

using SpareShop.Data.Repository._1_MainRepo;
using SpareShop.Domain.Entities;

namespace SpareShop.Data.Repository.OrderHeaderRepo
{
    public interface IOrderHeaderRepo : IRepo<OrderHeader, Guid>
    {
        void UpdateStatus(Guid id, string orderStatus, string paymentStatus );

        void UpdateStripePaymentId(Guid id, string sessionId, string paymentItentId);
    }
}