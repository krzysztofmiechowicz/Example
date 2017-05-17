using MOK.Interfaces.Repositories;
using MOK.Models;

namespace MOK.Repositories
{
    public class OrderWriteOnlyRepository : IOrderWriteOnlyRepository
    {
        public void AddOrder(OrderInputModel model)
        {
            var context = new MOKEntities();
            var addedOrder = context.Orders.Add(new Order
            {
                CreatedOn = model.CreateDate,
                CreatedBy = 1,
                Comment = model.Comment,
                DeliveryDate = model.DeliveryDate,
                DeliveryId = 1

            });
            context.SaveChanges();
            foreach (var item in model.Items)
            {
                context.OrderDetails.Add(new OrderDetail
                {
                    OrderId = addedOrder.Id,
                    Quantity = item.Quantity,
                    Comment = item.Comment,
                    OfferId = item.OfferId
                });
            }
            context.SaveChanges();                
        }
    }
}