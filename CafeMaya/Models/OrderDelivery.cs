using Microsoft.EntityFrameworkCore;

namespace CafeMaya.Models;

[PrimaryKey(nameof(OrderId), nameof(CourierId))]
public class OrderDelivery
{
    public int OrderId { get; set; }
    public int CourierId { get; set; }
    public Order Order { get; set; } = null!;
    public Courier? Courier { get; set; }

    public OrderDelivery(int orderId, int courierId)
    {
        OrderId = orderId;
        CourierId = courierId;
    }

    public OrderDelivery(Order order, Courier courier) : this(order.Id, courier.Id) { }
}