
namespace SpareShop.Domain.Entities;

public sealed class Product : IDbModel<Guid>
{
    public Product()
    {
        OrderDetails = new HashSet<OrderDetail>();
        Reviews = new HashSet<Review>();
        ShoppingCarts = new HashSet<ShoppingCart>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Manufacture { get; set; } = string.Empty;
    public string ModelNumber { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string ImgPath { get; set; } = string.Empty;

    [Range(1, 10000)]
    public double Price { get; set; } = 1;
    public int Count { get; set; }
    public byte[]? ProductPicture { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public Guid UserId { get; set; }
    public Brand Brand { get; set; } = new Brand();
    public Category Category { get; set; } = new Category();
    public User User { get; set; } = new User();
    public ICollection<OrderDetail> OrderDetails { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }


}