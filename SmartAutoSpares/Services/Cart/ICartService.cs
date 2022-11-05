using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes.Results;

namespace SmartAutoSpares.Services.Bookings
{
    public interface ICartService
    {
        IEnumerable<Models.CartItem> Get();
        Models.CartItem GetCartItem(int CartItemId);
        IOutcome<Models.CartItem> Remove(int autoSpareId, int UserId);
        IOutcome<Models.CartItem> Add(Models.AutoSpare autoSpare, int UserId);
    }
}
