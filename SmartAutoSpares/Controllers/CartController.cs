using Microsoft.AspNetCore.Mvc;
using SmartAutoSpares.Outcomes;
using SmartAutoSpares.Outcomes.Results;
using SmartAutoSpares.Services.Bookings;

namespace SmartAutoSpares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IHandler _outcomeHandler;
        private readonly ICartService _cartService;
        public CartController(ICartService cartService, IHandler outcomeHandler)
        {
            _cartService = cartService;
            _outcomeHandler = outcomeHandler;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_cartService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult GetCartItem(int id)
        {
            return Ok(_cartService.GetCartItem(id));
        }

        [HttpPost("userId/{userId}")]
        public ActionResult<IOutcome<Models.CartItem>> CreateCartItem(Models.AutoSpare autoSpare, int UserId)
        {
            return _outcomeHandler.HandleOutcome(_cartService.Add(autoSpare, UserId));
        }

        [HttpDelete("autoSpare/{autoSpareId}/user/{userId}")]
        public ActionResult<IOutcome<Models.CartItem>> RemoveItem(int autoSpareId, int UserId)
        {
            return _outcomeHandler.HandleOutcome(_cartService.Remove(autoSpareId, UserId));
        }
    }
}
