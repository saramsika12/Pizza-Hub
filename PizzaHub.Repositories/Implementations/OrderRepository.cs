using Microsoft.EntityFrameworkCore;
using PizzaHub.Entities;
using PizzaHub.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Repositories.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext appContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Order> GetUserOrders(int userId)
        {
            return appContext.Orders
                .Include(o => o.OrderItems)
                .Where(x => x.UserId == userId).ToList();
        }
    }
}
