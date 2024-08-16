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
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(await _bookRepository.GetAllBooks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            var createdBook = await _bookRepository.AddBook(book);
            return Ok(createdBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var createdBook = await _bookRepository.UpdateBook(book);
            return Ok(createdBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deleted = await _bookRepository.DeleteBook(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok("Buku telah dihapus");
        }
    }
}
