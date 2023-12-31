﻿
using BestAuto.Data.DTOs.BrandDtos;
using BestAuto.Data.Managers.Brands;
//using BestAuto.Data.SeedData;

namespace BestAuto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandsManager _brandsManager;

    public BrandsController(IBrandsManager brandsManager)
    {
        _brandsManager = brandsManager;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UpdateBrandDto>> GetAll()
    {
        //SeedData.Seed();
        return Ok(_brandsManager.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<UpdateBrandDto> GetById(int id)
    {
        var dto = _brandsManager.GetById(id);
        if (dto is null)
            return BadRequest("Not Found Brand");
        return Ok(dto);
    }

    [HttpGet]
    [Route("Count")]
    public ActionResult<int> GetCount()
    {
        return Ok(_brandsManager.GetAll().Count);
    }

    [HttpPost]
    [Authorize(Policy = "Manager")]
    public ActionResult<UpdateBrandDto> CreateBrand(AddBrandDto dto)
    {
        return Ok(_brandsManager.Add(dto));
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "Manager")]
    public ActionResult UpdateBrand(int id, UpdateBrandDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("Id not matched");
        }
        if (!_brandsManager.Update(dto))
        {
            return BadRequest("Not Updated");
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [Authorize(Policy = "Manager")]
    public ActionResult DeleteBrand(int id)
    {
        if (!_brandsManager.Delete(id))
        {
            return BadRequest("Not Deleted");
        }
        return NoContent();
    }
    
}