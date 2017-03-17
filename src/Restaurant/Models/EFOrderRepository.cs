using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Restaurant.Models {

    public class EFOrderRepository : IOrderRepository {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<Order> Orders => context.Orders
                            .Include(o => o.Lines)
                            .ThenInclude(l => l.Food);

        public void SaveOrder(Order order) {
            context.AttachRange(order.Lines.Select(l => l.Food));
            if (order.OrderID == 0) {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
