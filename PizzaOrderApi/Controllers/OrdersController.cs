using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaOrderApi.DataContext;
using PizzaOrderApi.Models;
using System.Linq;

namespace PizzaOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrdersDBContext _context;

        public OrdersController(OrdersDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _context.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            Order order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            //Determine the next ID
            int newID = _context.Orders.Any() ? _context.Orders.Select(x => x.Id).Max() + 1 : 1;
            order.Id = newID;

            _context.Orders.Add(order);
            _context.SaveChanges();

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return Accepted();
        }
    }
}
