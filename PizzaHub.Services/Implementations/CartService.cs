using PizzaHub.Entities;
using PizzaHub.Repositories.Implementations;
using PizzaHub.Repositories.Interfaces;
using PizzaHub.Repositories.Models;
using PizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IRepository<CartItem> _cartItem;

        public CartService(ICartRepository cartRepo,
            IRepository<CartItem> cartItem)
        {
            _cartRepo = cartRepo;
            _cartItem = cartItem;
        }
        public Cart AddItem(int UserId, Guid CartId, int ItemId, decimal UnitPrice, int Quantity)
        {
            try
            {
                Cart cart = _cartRepo.GetCart(CartId);
                if (cart == null)
                {
                    cart = new Cart
                    {
                        Id = CartId,
                        UserId = UserId,
                        CreateDate = DateTime.Now
                    };
                    CartItem item = new CartItem(ItemId, Quantity, UnitPrice) { CartId = cart.Id };
                    cart.Items.Add(item);
                    _cartRepo.Add(cart);



                }
                else
                {
                    
                    CartItem item = cart.Items.FirstOrDefault(p => p.ItemId == ItemId);
                    if (item != null)
                    {
                        // Update quantity if item exists
                        item.Quantity += Quantity;
                        _cartItem.Update(item);
                    }
                    else
                    {
                        // Add item if it doesn't exist
                        item = new CartItem(ItemId, Quantity, UnitPrice) { CartId = cart.Id };
                        cart.Items.Add(item);
                    }
                }
                _cartRepo.SaveChanges();
                return cart;
            

            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public int DeleteItem(Guid cartId, int ItemId)
        {
            return _cartRepo.DeleteItem(cartId, ItemId);
        }

        public int GetCartCount(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
                return 0;

            if (!Guid.TryParse(cartId, out Guid cartGuid))
                throw new ArgumentException("Invalid cart ID format.");

            var cart = _cartRepo.GetCart(cartGuid); // Call repository
            return cart != null ? cart.Items.Count() : 0;
        }

        public CartModel GetCartDetails(Guid cartId)
        {
            var model = _cartRepo.GetCartDetails(cartId);
            if(model != null && model.Items.Count > 0)
            {
                decimal subTotal = 0;
                foreach(var item in model.Items)
                {
                    item.Total = item.UnitPrice * item.Quantity;
                    subTotal += item.Total;

                }
                model.Total = subTotal;
                //5% tax
                model.Tax = Math.Round((model.Total * 5) / 100, 2);
                model.GrandTotal = model.Total + model.Tax;
            }
            return model;
        }

        public int UpdateCart(Guid CartId, int UserId)
        {
            return _cartRepo.UpdateCart(CartId, UserId);
        }

        public int UpdateQuantity(Guid cartId, int id, int quantity)
        {
            return _cartRepo.UpdateQuantity(cartId, id, quantity);
        }
    }
}
