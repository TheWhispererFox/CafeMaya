using System.ComponentModel.DataAnnotations;

namespace CafeMaya.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<OrderItem>? Items { get; set; }
    public OrderStatus Status { get; set; }
    public OrderDelivery? Delivery { get; set; }
    public double Total => Items?.Sum(x => x.Quantity * x.Item.Price) ?? 0;
    
    public enum OrderStatus
    {
        Awaiting,
        Complete,
        Cooking,
        AwaitingDelivery,
        Delivery,
        Canceled
    }
}

