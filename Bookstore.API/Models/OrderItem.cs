namespace Bookstore.API.Models;

public class OrderItem
{
    public int BookId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}   