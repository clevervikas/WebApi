using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DAL;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _orders;

        public OrderController(IOrderRepo order)
        {
            _orders = order;
        }

        [HttpGet("")]
        public IActionResult getAllOrders()
        {
            List<Order> orders = _orders.GetAllOrders();
            return Ok(orders);
        }


        [HttpGet("{id}")]
        public IActionResult GetOrder(long id)
        {
            Order order = _orders.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            Order createdOrder = _orders.CreateOrder(order);

            return CreatedAtAction(
                nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(long id, [FromBody] Order order)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _orders.UpdateOrder(id, order);
                return Ok();
            }
            catch (EntityNotFoundException<Order>)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(long id)
        {
            _orders.DeleteOrder(id);
            return Ok();
        }
    }
}