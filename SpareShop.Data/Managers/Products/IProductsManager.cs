

using SpareShop.Data.DTOs.ProductDtos;
using SpareShop.Domain.Entities;

namespace SpareShop.Data.Managers.Products;

public interface IProductsManager
{
    IEnumerable<SimpleProductDto> GetAll(string[]? include = null!);
    List<ReadProductDto> GetAllOwn(Guid userId);
    ReadProductDto? GetById(Guid id);
    ReadProductDto Add(AddProductDto dto, User user);
    bool Update(UpdateProductDto dto);
    bool Delete(Guid id);

}