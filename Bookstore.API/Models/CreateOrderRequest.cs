
namespace Bookstore.API.Models;

public class CreateOrderRequest
{
    public string CustomerName { get; set; } = string.Empty;

    public List<OrderItem> Items { get; set; } = new();
}
