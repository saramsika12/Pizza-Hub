﻿using PizzaHub.Entities;
using PizzaHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Interfaces
{
    public interface ICartService
    {
        int GetCartCount(string cartId);

        CartModel GetCartDetails(Guid cartId);
        Cart AddItem(int UserId, Guid CartId, int ItemId, decimal
            UnitPrice, int Quantity);
        
        int DeleteItem(Guid cartId, int ItemId);

        int UpdateQuantity(Guid cartId, int id
            , int quantity);

        int UpdateCart(Guid CartId, int UserId);
    }
}
