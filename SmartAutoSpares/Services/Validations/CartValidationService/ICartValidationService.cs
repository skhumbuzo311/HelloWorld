namespace SmartAutoSpares.Services.Validations.CartValidations
{
    public interface ICartValidationService
    {
        (bool canAction, string error) CanAdd(int cartItemId, int autoSpareId);
        (bool canAction, string error) CanRemove(Entities.OrderedItem orderedItem);
    }
}
