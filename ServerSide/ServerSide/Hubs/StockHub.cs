using Microsoft.AspNetCore.SignalR;
using ServerSide.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ServerSide.Hubs
{
    public class StockHub : Hub
    {
        public async Task NotifyStockPriceUpdate(int stockId, decimal price)
        {
            await Clients.All.SendAsync("UpdateStockPrice", stockId, price);
        }

    }
}