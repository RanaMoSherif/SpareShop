using BestAuto.Data.DTOs.BrandDtos;
using BestAuto.Data.Managers.Brands;
using BestAuto.Data.Repository._0_UnitOfWork;
using BestAuto.Domain.Entities;

namespace BestAuto.Tests
{
    public class BrandsManagerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BrandsManager _brandsManager;

        public BrandsManagerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _brandsManager = new BrandsManager(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnMappedBrands()
        {
            // Arrange
            var brands = new List<Brand> { new Brand() };
            _unitOfWorkMock.Setup(u => u.Brand.GetAll(It.IsAny<string[]>())).Returns(brands);
            _mapperMock.Setup(m => m.Map<List<ReadBrandDto>>(brands)).Returns(new List<ReadBrandDto> { new ReadBrandDto() });

            // Act
            var result = _brandsManager.GetAll();

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public void GetById_ShouldReturnMappedBrand()
        {
            // Arrange
            var brand = new Brand();
            _unitOfWorkMock.Setup(u => u.Brand.Get(It.IsAny<int>())).Returns(brand);
            _mapperMock.Setup(m => m.Map<ReadBrandDto>(brand)).Returns(new ReadBrandDto());

            // Act
            var result = _brandsManager.GetById(1);

            // Assert
            Assert.NotNull(result);
        }
    }
}