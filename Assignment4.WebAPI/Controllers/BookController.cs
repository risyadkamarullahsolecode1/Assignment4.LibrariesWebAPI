using Assignment4.Domain.Entities;
using Assignment4.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookRepository.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            _bookRepository.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
            return NoContent();
        }
    }
}
