namespace CafeMaya.Models;

public class OrderItem
{
    public int OrderId { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int Quantity { get; set; }
    public double Subtotal => Quantity * Item.Price;

    public OrderItem(int orderId, int itemId, int quantity = 1)
    {
        OrderId = orderId;
        ItemId = itemId;
        Quantity = quantity;
    }

    public OrderItem(int orderId, Item item, int quantity = 1)
    {
        OrderId = orderId;
        Item = item;
        Quantity = quantity;
    }

    public OrderItem(Item item, int quantity = 1)
        : this(0, item, quantity) { }
}