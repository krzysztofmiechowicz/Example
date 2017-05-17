using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MOK.Interfaces.Repositories;
using MOK.Models;

namespace MOK.Repositories
{
    public class OrderReadOnlyRepository : IOrderReadOnlyRepository
    {
        public IEnumerable<Order> GetAllOrders()
        {
            var context = new MOKEntities();
            return context.Orders;
        }

        public IEnumerable<Order> GetMyOrders(int userId)
        {
            var context = new MOKEntities();
            return context.Orders.Where(order => order.CreatedBy == userId);
        }

       public IQueryable<OrderDetail> GetOrderDetails(int orderId)
        {
            var context = new MOKEntities();
            return context.OrderDetails.Where(orderDetails => orderDetails.OrderId == orderId)
                .Include("Offer");
        }
    }
}