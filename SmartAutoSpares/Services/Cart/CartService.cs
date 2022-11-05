using System.Collections.Generic;
using System.Linq;
using SmartAutoSpares.Context;
using SmartAutoSpares.Entities;
using Microsoft.EntityFrameworkCore;
using SmartAutoSpares.Outcomes.Results;
using System.Threading.Tasks;
using System;
using SmartAutoSpares.Services.Converters;
using SmartAutoSpares.Services.Validations.CartValidations;

namespace SmartAutoSpares.Services.Bookings
{
    public class CartService : ICartService
    {
        private readonly SmartAutoSparesDbContext _smartAutoSpareDbContext;
        private readonly ICartValidationService _cartValidationService;


        public CartService(SmartAutoSparesDbContext smartAutoSparesDbContext, ICartValidationService cartValidationService)
        {
            _cartValidationService = cartValidationService;
            _smartAutoSpareDbContext = smartAutoSparesDbContext;
        }

        public IEnumerable<Models.CartItem> Get()
        {
            return _smartAutoSpareDbContext.CartItems
                    .Include(ci => ci.Status)
                    .Include(ci => ci.OrderedItems)
                        .ThenInclude(oi => oi.AutoSpare)
                            .ThenInclude(s => s.Images)
                    .OrderByDescending(f => f.CreatedAt)
                    .Where(ci => ci.OrderedItems.Any())
                    .Select(ci => CartConverter.ConvertCartItemToModel(ci))
                    .ToList();
        }

        public Models.CartItem GetCartItem(int CartItemId)
        {
            var cartItem = _smartAutoSpareDbContext.CartItems
                    .Include(b => b.Status)
                    .Include(ci => ci.OrderedItems)
                        .ThenInclude(oi => oi.AutoSpare)
                            .ThenInclude(s => s.Images)
                    .Single(b => b.Id == CartItemId);

            return CartConverter.ConvertCartItemToModel(cartItem);
        }

        public IOutcome<Models.CartItem> Add(Models.AutoSpare autoSpare, int UserId)
        {
            var activeCartItem = _smartAutoSpareDbContext.CartItems.SingleOrDefault(ci => !ci.IsPaymentComplete && ci.UserId == UserId);

            (bool canAction, string error) = _cartValidationService.CanAdd(activeCartItem.Id, autoSpare.Id);
            if (!canAction)
            {
                return new Failure<Models.CartItem>(error);
            }

            if (activeCartItem == null)
            {
                activeCartItem = new CartItem()
                {
                    UserId = UserId,
                    StatusId = _smartAutoSpareDbContext.CartItemStatuses.Single(s => s.Description == "Awaiting Payment").Id,
                    TotalCost = autoSpare.Price,
                    CreatedAt = DateTime.Now
                };

                _smartAutoSpareDbContext.CartItems.Add(activeCartItem);
                
                _smartAutoSpareDbContext.SaveChanges();                
            }
            else
            {
                _smartAutoSpareDbContext.OrderedItems.Add(new OrderedItem
                {
                    CartItemId = activeCartItem.Id,
                    AutoSpareId = autoSpare.Id,
                });

                activeCartItem.TotalCost = activeCartItem.TotalCost + autoSpare.Price;
                
                _smartAutoSpareDbContext.SaveChanges();
            }
            _smartAutoSpareDbContext.SaveChanges();

            return new Success<Models.CartItem>(GetCartItem(activeCartItem.Id));
        }

        public IOutcome<Models.CartItem> Remove(int autoSpareId, int UserId)
        {
            var activeCartItem = _smartAutoSpareDbContext.CartItems.SingleOrDefault(ci => !ci.IsPaymentComplete && ci.UserId == UserId);
            var orderedItem = _smartAutoSpareDbContext.OrderedItems.SingleOrDefault(oi => oi.CartItemId == activeCartItem.Id && oi.AutoSpareId == autoSpareId);

            (bool canAction, string error) = _cartValidationService.CanRemove(orderedItem);
            if (!canAction)
            {
                return new Failure<Models.CartItem>(error);
            }

            _smartAutoSpareDbContext.OrderedItems.Remove(orderedItem);

            _smartAutoSpareDbContext.SaveChanges();

            return new Success<Models.CartItem>(GetCartItem(activeCartItem.Id));
        }
    }
}
