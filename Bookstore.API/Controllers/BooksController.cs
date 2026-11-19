using Bookstore.API.Models;
using Bookstore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<List<Book>> GetAllBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = _bookService.GetBookById(id);

        if (book == null)
        {
            return NotFound(new { message = "Book not found" });
        }

        return Ok(book);
    }
    [HttpGet("search")]
    public ActionResult<List<Book>> SearchBooks([FromQuery] string title)
    {
        var books = _bookService.SearchBooks(title);
        return Ok(books);
    }
}
