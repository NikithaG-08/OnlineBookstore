using Bookstore.API.Models;
using Bookstore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<List<Order>> GetAllOrders()
    {
        return Ok(_orderService.GetAllOrders());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Order> GetOrderById(int id)
    {
        var order = _orderService.GetOrderById(id);

        if (order == null)
            return NotFound(new { message = "Order not found" });

        return Ok(order);
    }

    [HttpPost]
    public ActionResult<Order> CreateOrder([FromBody] Order order)
    {
        try
        {
            var createdOrder = _orderService.CreateOrder(order);

            return CreatedAtAction(
                nameof(GetOrderById),
                new { id = createdOrder.Id },
                createdOrder);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}