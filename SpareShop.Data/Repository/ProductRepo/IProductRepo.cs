

using SpareShop.Data.Repository._1_MainRepo;
using SpareShop.Domain.Entities;

namespace SpareShop.Data.Repository.ProductRepo
{
    public interface IProductRepo : IRepo<Product, Guid>
    {
    }
}