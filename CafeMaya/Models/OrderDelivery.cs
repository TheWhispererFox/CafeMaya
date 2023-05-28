using System.ComponentModel.DataAnnotations;

namespace CafeMaya.Models;

public class OrderDelivery
{
    [Key] public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public string Address { get; set; }
    public int CourierId { get; set; }
    public Courier? Courier { get; set; }

    public OrderDelivery(int orderId, string address)
    {
        OrderId = orderId;
        Address = address;
    }

    public OrderDelivery(Order order, string address) : this(order.Id, address) { }
}