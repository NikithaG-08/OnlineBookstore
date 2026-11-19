using Bookstore.API.Models;

namespace Bookstore.API.Services;

public interface IOrderService
{
    List<Order> GetAllOrders();
    Order? GetOrderById(int id);
    Order CreateOrder(Order order);
}