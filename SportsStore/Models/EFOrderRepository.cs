using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;
        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
            .Include(x => x.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Product));
            if(order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
