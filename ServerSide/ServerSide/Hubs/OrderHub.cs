using Microsoft.AspNetCore.SignalR;
using ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide.Hubs
{
    public class OrderHub:Hub
    {
        public async Task SendOrder(Order order)
        {
            // Broadcast the new order to all connected clients
            await Clients.All.SendAsync("ReceiveOrder", order);
        }
    }
}
