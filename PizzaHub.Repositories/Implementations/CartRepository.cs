using Microsoft.EntityFrameworkCore;
using PizzaHub.Entities;
using PizzaHub.Repositories.Interfaces;
using PizzaHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaHub.Repositories.Implementations
{
	public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext appContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public CartRepository(AppDbContext dbContext) : base(dbContext)
        {

        }


		public int DeleteItem(Guid cartId, int itemId)
		{
			var item = appContext.CartItems.Where(ci => ci.CartId == cartId && ci.Id ==
			itemId).FirstOrDefault();
			if (item != null)
			{
				appContext.CartItems.Remove(item);
				return appContext.SaveChanges();
			}
			else
			{
				return 0;
			}
		}

		public Cart GetCart(Guid CartId)
		{
			return appContext.Carts.Include("Items").Where(c => c.Id == CartId &&
			 c.IsActive == true).FirstOrDefault();
		}

		public int GetCart(Guid cartId, int itemId)
		{
			throw new NotImplementedException();
		}

		public int UpdateCart(Guid cartId, int userId)
		{
			Cart cart = GetCart(cartId);
			cart.UserId = userId;
			return appContext.SaveChanges();
		}

		public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
		{
			//bool flag = false;
			//var cart = GetCart(cartId);
			//if (cart != null)
			//{
			//	for (int i = 0; i < cart.Items.Count; i++)
			//	{
			//		if (cart.Items[i].Id == itemId)
			//		{
			//			flag = true;
			//			//for minus quantity
			//			if (Quantity > 0 && cart.Items[i].Quantity > 1)
			//				cart.Items[i].Quantity += (Quantity);
			//			else if (Quantity > 0)
			//				cart.Items[i].Quantity += (Quantity);
			//			break;
			//		}
			//	}
			//	if (flag)
			//		return appContext.SaveChanges();
			//}
			//return 0;

			var cart = GetCart(cartId);
			if (cart != null)
			{
				var item = cart.Items.FirstOrDefault(ci => ci.Id == itemId);
				if (item != null)
				{
					// Ensure quantity does not go below 1
					int updatedQuantity = item.Quantity + Quantity;
					if (updatedQuantity >= 1)
					{
						item.Quantity = updatedQuantity;
						return appContext.SaveChanges();
					}
				}
			}
			return 0;
		}

		public CartModel GetCartDetails(Guid cartId)
		{
			var model = (from cart in appContext.Carts
						 where cart.Id == cartId && cart.IsActive == true
						 select new CartModel
						 {
							 Id = cart.Id,
							 UserId = cart.UserId,
							 CreateDate = cart.CreateDate,
							 Items = (from cartItem in
										  appContext.CartItems
									  join item in appContext.Items
									  on cartItem.ItemId equals item.Id
									  where cartItem.CartId == cartId
									  select new ItemModel
									  {
										  Id = cartItem.Id,
										  Name = item.Name,
										  Description = item.Description,
										  ImageUrl = item.ImageUrl,
										  Quantity = cartItem.Quantity,
										  ItemId = item.Id,
										  UnitPrice = cartItem.UnitPrice,
									  }).ToList()
						 }).FirstOrDefault();
			return model;
		}

	}
}
