

using BestAuto.Data.Repository._1_MainRepo;
using BestAuto.Domain.Entities;

namespace BestAuto.Data.Repository.ProductRepo
{
    public interface IProductRepo : IRepo<Product, Guid>
    {
    }
}