

using BestAuto.Data.DTOs.BrandDtos;

namespace BestAuto.Data.Managers.Brands;

public interface IBrandsManager
{
    List<ReadBrandDto> GetAll(string[]? include = null!);
    ReadBrandDto? GetById(int id);
    ReadBrandDto Add(AddBrandDto model);
    bool Update(UpdateBrandDto model);
    bool Delete(int id);

}