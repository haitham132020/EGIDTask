using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ServerSide.Hubs;
using ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly List<Order> _orders; // Replace with your data access layer
        private readonly IHubContext<OrderHub> _hubContext;

        public OrdersController(IHubContext<OrderHub> hubContext)
        {
            // Initialize orders (replace with your data access layer)
            _orders = new List<Order>();
            _hubContext = hubContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(_orders);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            // Validate the order and perform any necessary processing
            _orders.Add(order); // Replace with your data access layer

            // Send the new order to connected clients via SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveOrder", order);

            return CreatedAtAction(nameof(GetOrders), order);
        }
    }
}
