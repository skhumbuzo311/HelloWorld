using System.Linq;
using SmartAutoSpares.Entities;

namespace SmartAutoSpares.Services.Converters
{
    public static class CartConverter
    {
        public static Models.CartItem ConvertCartItemToModel(CartItem cartItem)
        {
            return new Models.CartItem()
            {
                Id = cartItem.Id,
                Status = cartItem.Status.Description,
                TotalCost = cartItem.OrderedItems.Sum(oi => oi.AutoSpare.Price),
                CreatedAt = cartItem.CreatedAt,
                imagesUrls = cartItem.OrderedItems.Select(oi => oi.AutoSpare.Images.First().URL),
                OrderedItems = cartItem.OrderedItems.Select(oi => AutoSparesConverter.ConvertAutoSpareToModel(oi.AutoSpare))
            };
        }
    }
}
