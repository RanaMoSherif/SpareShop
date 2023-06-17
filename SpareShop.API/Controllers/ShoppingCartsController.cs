
using SpareShop.Data.DTOs.ShoppingCartDtos;
using SpareShop.Data.Managers.ShoppingCart;
using SpareShop.Domain.Entities;

namespace SpareShop.API.Controllers;

[Route("api/[controller]")]

[ApiController]
public class ShoppingCartsController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IShoppingCartsManager _shoppingCartsManager;

    public ShoppingCartsController(UserManager<User> userManager, IShoppingCartsManager shoppingCartsManager)
    {
        _userManager = userManager;
        _shoppingCartsManager = shoppingCartsManager;
    }

    [HttpGet]
    [Authorize(Policy = "Client")]
    public async Task<ActionResult<IEnumerable<ReadShoppingCartDto>>> GetAll()
    {
        IEnumerable<ReadShoppingCartDto> shoppingCart = new List<ReadShoppingCartDto>();
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser !=null)
        {
            shoppingCart = _shoppingCartsManager.GetAll().Where(c => c.UserId == currentUser!.Id);
            return Ok(shoppingCart);
        }
        else
        {
            return BadRequest("User Not Found or Not Signed In");
        }
    }

    [HttpPost]
    [Authorize(Policy = "Client")]
    public async Task<ActionResult<UpdateShoppingCartDto>> AssignProduct(AssignProductToCartDto dto)
    {
        var currentUser = await _userManager.GetUserAsync(User);

        if (currentUser != null)
        {
            dto.UserId = currentUser!.Id;
            return Ok(await _shoppingCartsManager.AssignProduct(dto));
        }
        else
        {
            return BadRequest("User Not Found or Not Signed In");
        }
    }

    [HttpPut("IncrementCount")]
    [Authorize(Policy = "Client")]
    public async Task<ActionResult> IncrementCount(Guid productId)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var dto = new UpdateShoppingCartDto { ProductId = productId, UserId = currentUser!.Id };
        if (!_shoppingCartsManager.IncrementCount(dto))
        {
            return BadRequest("Not Updated");
        }

        return NoContent();
    }

    [HttpPut("DecrementCount")]
    [Authorize(Policy = "Client")]
    public async Task<ActionResult> DecrementCount(Guid productId)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var dto = new UpdateShoppingCartDto { ProductId = productId, UserId = currentUser!.Id };
        if (!_shoppingCartsManager.DecrementCount(dto))
        {
            return BadRequest("Not Updated");
        }

        return NoContent();
    }

    [HttpPut("ChangeCount")]
    [Authorize(Policy = "Client")]
    public async Task<ActionResult> ChangeCount(Guid productId, int count)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var dto = new ChangeCountShoppingCartDto{ ProductId = productId, UserId = currentUser!.Id, Count = count};
        if (!_shoppingCartsManager.ChangeCount(dto))
        {
            return BadRequest("Not Updated");
        }

        return NoContent();
    }

    [HttpDelete]
    [Authorize(Policy = "Client")]
    public async Task<ActionResult> DeleteShoppingCart(Guid productId)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var dto = new DeleteShoppingCartDto{ ProductId = productId, UserId = currentUser!.Id};

        if (!_shoppingCartsManager.Delete(dto))
        {
            return BadRequest("Not Deleted");
        }
        return NoContent();
    }
    
}