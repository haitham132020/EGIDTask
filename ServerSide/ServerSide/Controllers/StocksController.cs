using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServerSide.Hubs;
using ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IHubContext<StockHub> _hubContext;
        private static readonly Random _random = new Random();
        private static List<Stock> _stocks;

        public StocksController(IHubContext<StockHub> hubContext)
        {
            _hubContext = hubContext;

            if (_stocks == null)
            {
                _stocks = GenerateInitialStocks();
                StartStockPriceUpdates();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Stock>> GetStocks()
        {
            return Ok(_stocks);
        }

        private static List<Stock> GenerateInitialStocks()
        {
            var stocks = new List<Stock>
            {
                new Stock { Id = 1, Name = "Stock A", Price = GetRandomPrice() },
                new Stock { Id = 2, Name = "Stock B", Price = GetRandomPrice() },
                new Stock { Id = 3, Name = "Stock C", Price = GetRandomPrice() }
            };

            return stocks;
        }

        private static decimal GetRandomPrice()
        {
            return _random.Next(1, 100);
        }

        private void StartStockPriceUpdates()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(10000);

                    foreach (var stock in _stocks)
                    {
                        stock.Price = GetRandomPrice();
                        await _hubContext.Clients.All.SendAsync("NotifyStockPriceUpdate", stock.Id, stock.Price);
                    }
                }
            });
        }
    }
