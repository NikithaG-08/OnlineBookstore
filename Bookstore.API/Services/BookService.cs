
using Bookstore.API.Models;

namespace Bookstore.API.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = new()
    {
        new Book
        {
            Id = 1,
            Title = "Clean Code",
            Author = "Robert C. Martin",
            ISBN = "9780132350884",
            Price = 450,
            StockQuantity = 10
        },
        new Book
        {
            Id = 2,
            Title = "The Pragmatic Programmer",
            Author = "Andrew Hunt",
            ISBN = "9780135957059",
            Price = 550,
            StockQuantity = 8
        },
        new Book
        {
            Id = 3,
            Title = "Atomic Habits",
            Author = "James Clear",
            ISBN = "9780735211292",
            Price = 399,
            StockQuantity = 15
        }
    };

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    public Book? GetBookById(int id)
    {
        return _books.FirstOrDefault(book => book.Id == id);
    }
    public List<Book> SearchBooks(string title)
    {
        return _books
            .Where(book => book.Title.Contains(
                title,
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
