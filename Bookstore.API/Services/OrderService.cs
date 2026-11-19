
using Bookstore.API.Models;

namespace Bookstore.API.Services;

public class OrderService : IOrderService
{
    private readonly IBookService _bookService;
    private readonly List<Order> _orders = new();
    private int _nextOrderId = 1;

    public OrderService(IBookService bookService)
    {
        _bookService = bookService;
    }

    public List<Order> GetAllOrders()
    {
        return _orders;
    }

    public Order? GetOrderById(int id)
    {
        return _orders.FirstOrDefault(order => order.Id == id);
    }

    public Order CreateOrder(Order order)
    {
        if (string.IsNullOrWhiteSpace(order.CustomerName))
            throw new ArgumentException("Customer name is required.");

        if (order.Items == null || order.Items.Count == 0)
            throw new ArgumentException("At least one order item is required.");

        decimal totalAmount = 0;

        foreach (var item in order.Items)
        {
            if (item.Quantity < 1)
                throw new ArgumentException("Quantity must be at least 1.");

            var book = _bookService.GetBookById(item.BookId);

            if (book == null)
                throw new ArgumentException(
                    $"Book with ID {item.BookId} was not found.");

            item.Price = book.Price;
            totalAmount += item.Price * item.Quantity;
        }

        order.Id = _nextOrderId++;
        order.TotalAmount = totalAmount;
        order.Status = "Pending";

        _orders.Add(order);

        return order;
    }
}
    