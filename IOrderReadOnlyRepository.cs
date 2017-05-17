using System.Collections.Generic;
using System.Linq;
using MOK.Models;

namespace MOK.Interfaces.Repositories
{
    public interface IOrderReadOnlyRepository
    {
        IEnumerable<Order> GetAllOrders();

        IEnumerable<Order> GetMyOrders(int userId);

        IQueryable<OrderDetail> GetOrderDetails(int orderId);
    }
}