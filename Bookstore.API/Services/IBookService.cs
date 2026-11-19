using Bookstore.API.Models;

namespace Bookstore.API.Services;

public interface IBookService
{
    List<Book> GetAllBooks();

    Book? GetBookById(int id);

    List<Book> SearchBooks(string title);
}