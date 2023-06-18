

using BestAuto.Data.DTOs.ProductDtos;
using BestAuto.Domain.Entities;

namespace BestAuto.Data.Managers.Products;

public interface IProductsManager
{
    IEnumerable<SimpleProductDto> GetAll(string[]? include = null!);
    List<ReadProductDto> GetAllOwn(Guid userId);
    ReadProductDto? GetById(Guid id);
    ReadProductDto Add(AddProductDto dto, User user);
    bool Update(UpdateProductDto dto);
    bool Delete(Guid id);

}