using Asp.Versioning;
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
        /// <summary>
        /// You get, get by id or delete here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     GET /api/v1/Book
        ///     
        ///     OR
        ///     
        ///     GET /api/v1/{id}
        ///    
        ///     OR
        ///     
        ///     DELETE /api/v1/{id}
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(await _bookRepository.GetAllBooks());
        }
        /// <summary>
        /// You get, get by id or delete here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     GET /api/v1/Book
        ///     
        ///     OR
        ///     
        ///     GET /api/v1/Book/{id}
        ///    
        ///     OR
        ///     
        ///     DELETE /api/v1/Book/{id}
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }
        /// <summary>
        /// You can add or update book here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     POST /api/v1/Book
        ///     {
        ///        "id": null,
        ///        "title": "string",
        ///        "author": "string",
        ///        "publicationYear": 0,
        ///        "isbn": "string"
        ///     }
        ///     OR
        ///     
        ///     PUT /api/v1/Book/{id}
        ///     {
        ///        "id": null,
        ///        "title": "string",
        ///        "author": "string",
        ///        "publicationYear": 0,
        ///        "isbn": "string"
        ///     } 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            var createdBook = await _bookRepository.AddBook(book);
            return Ok(createdBook);
        }
        /// <summary>
        /// You can add or update book here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     POST /api/v1/Book
        ///     {
        ///        "id": null,
        ///        "title": "string",
        ///        "author": "string",
        ///        "publicationYear": 0,
        ///        "isbn": "string"
        ///     }
        ///     OR
        ///     
        ///     PUT /api/v1/Book/{id}
        ///     {
        ///        "id": null,
        ///        "title": "string",
        ///        "author": "string",
        ///        "publicationYear": 0,
        ///        "isbn": "string"
        ///     } 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var createdBook = await _bookRepository.UpdateBook(book);
            return Ok(createdBook);
        }
        /// <summary>
        /// You get, get by id or delete here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     GET /api/v1/Book
        ///     
        ///     OR
        ///     
        ///     GET /api/v1/Book/{id}
        ///    
        ///     OR
        ///     
        ///     DELETE /api/v1/Book/{id}
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
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
