using CafeMaya.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeMaya.Services;

public class OrderDataProvider : DbContext, IDataProvider<Order>, IDataProviderAsync<Order>
{
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<OrderDelivery> OrderDeliveries { get; set; } = null!;
    public DbSet<Courier> Couriers { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItem>().HasKey(oi => new
        {
            oi.OrderId, oi.ItemId
        });
        base.OnModelCreating(modelBuilder);
    }

    public OrderDataProvider(DbContextOptions options) : base(options) { }


    #region IDataProvider
    public IEnumerable<Order>? Get() => Orders.ToList();
    public Order? Get(int id) => Orders.Find(id);

    public IEnumerable<Order> Get(Predicate<Order> predicate) => Orders.Where(o => predicate(o)).ToList();

    public void Add(Order obj)
    {
        if (Orders.Find(obj.Id) == null) Orders.Add(obj);
    }

    public void AddRange(IEnumerable<Order> list)
    {
        foreach (Order order in list)
        {
            if (Orders.Find(order.Id) == null)
                Orders.Add(order);
            else
                Orders.Attach(order);
        }
    }

    public void Remove(Order obj)
    {
        if (Orders.Find(obj.Id) == null)
        {
            Orders.Remove(obj);
        }
    }

    public void Remove(int id)
    {
        var order = Orders.Find(id);
        if (order == null) return;
        Remove(order);
    }

    public void RemoveRange(Predicate<Order> predicate)
    {
        var orders = Orders.Where(o => predicate(o));
        if (!orders.Any()) return;
        foreach (Order order in orders)
        {
            Orders.Remove(order);
        }
    }
    #endregion

    #region IDataProviderAsync
    public async Task<IEnumerable<Order>?> GetAsync() => await Orders.ToListAsync();
    public async Task<Order?> GetAsync(int id) => await Orders.FindAsync(id);
    public async Task<IEnumerable<Order>?> GetAsync(Predicate<Order> predicate) => await Orders.Where(o => predicate(o)).ToListAsync();
    public async Task AddAsync(Order obj) => await Orders.AddAsync(obj);
    public async Task AddRangeAsync(IEnumerable<Order> list) => await Orders.AddRangeAsync(list);
    #endregion
}