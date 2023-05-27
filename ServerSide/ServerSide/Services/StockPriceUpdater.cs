using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using ServerSide.Hubs;
using ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSide.Services
{
    public class StockPriceUpdater : BackgroundService
    {
        private readonly IHubContext<StockHub> _hubContext;
        private static readonly Random _random = new Random();

        public StockPriceUpdater(IHubContext<StockHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Update stock prices in the database or in-memory storage
                // Retrieve the stocks and update their prices

                // Broadcast the updated prices to connected clients via SignalR
                await _hubContext.Clients.All.SendAsync("UpdateStockPrices", GetStocks());

                // Wait for 10 seconds before updating the prices again
                await Task.Delay(10000, stoppingToken);
            }
        }

        private List<Stock> GetStocks()
        {
            // Retrieve stocks from the database or in-memory storage
            var stocks = new List<Stock>
        {
            new Stock { Id = 1, Name = "ABC", Price = GetRandomPrice() },
            new Stock { Id = 2, Name = "DEF", Price = GetRandomPrice() },
            // Add more stocks as needed
        };

            return stocks;
        }

        private decimal GetRandomPrice()
        {
            // Generate a random price between 1 and 100
            return _random.Next(1, 101);
        }
    }
}