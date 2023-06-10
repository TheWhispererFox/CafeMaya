using CafeMaya.Models;
using Microsoft.AspNetCore.SignalR;

namespace CafeMaya.Hubs;

public class NotificationHub : Hub
{
    public async Task SendNewOrderNotification(int newOrderId)
    {
        await Clients.All.SendAsync("NewOrder", newOrderId);
    }
}