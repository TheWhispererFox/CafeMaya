using System.ComponentModel.DataAnnotations.Schema;

namespace CafeMaya.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<OrderItem>? Items { get; set; }
    public OrderStatus Status { get; set; }
    public OrderDelivery? Delivery { get; set; }
    public string? Address { get; set; }
    [NotMapped] public bool IsForDelivery { get; set; }
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

