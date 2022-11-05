using System.Linq;
using SmartAutoSpares.Context;
using SmartAutoSpares.Outcomes.Results;

namespace SmartAutoSpares.Services.Validations.CartValidations
{
    public class CartValidationService : ICartValidationService
    {
        private readonly SmartAutoSparesDbContext _smartAutoSpareDbContext;

        public CartValidationService(SmartAutoSparesDbContext smartAutoSparesDbContext)
        {
            _smartAutoSpareDbContext = smartAutoSparesDbContext;
        }

        public (bool canAction, string error) CanAdd(int cartItemId, int autoSpareId)
        {
            if (_smartAutoSpareDbContext.OrderedItems.Any(oi => oi.CartItemId == cartItemId && oi.AutoSpareId == autoSpareId))
            {
                return (false, "Item already added");
            }

            return (true, string.Empty);
        }

        public (bool canAction, string error) CanRemove(Entities.OrderedItem orderedItem)
        {
            if (orderedItem == null)
            {
                return (false, $"Item is not part of your ative cart");
            }

            return (true, string.Empty);
        }
    }
}
