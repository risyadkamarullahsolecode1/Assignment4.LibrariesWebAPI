using Assignment4.Domain.Entities;
using Assignment4.Application;
using Microsoft.AspNetCore.Mvc;
using Assignment4.Application.Interfaces;
using Asp.Versioning;

namespace Assignment4.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class BookManagerController : ControllerBase
    {
        private readonly IBookManagerService _bookManagerService;

        public BookManagerController(IBookManagerService bookManagerService)
        {
            _bookManagerService = bookManagerService;
        }

        [HttpPost("borrow")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> BorrowBook([FromQuery] int userId, [FromQuery] int bookId)
        {
            try
            {
                await _bookManagerService.BorrowBook(userId, bookId);
                return Ok("Book borrowed successfully.");
            }
            catch (InvalidOperationException ex)
            {
                // Handle case where the user has reached the borrowing limit
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions
                return StatusCode(500, "An error occurred while borrowing the book.");
            }
        }

        [HttpPost("return")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> ReturnBook([FromQuery] int userId, [FromQuery]  int bookId)
        {
            try
            {
                await _bookManagerService.ReturnBook(userId, bookId);
                return Ok("Book returned successfully.");
            }
            catch (InvalidOperationException ex)
            {
                // Handle case where the user has reached the borrowing limit
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions
                return StatusCode(500, "An error occurred while borrowing the book.");
            }
        }
    }
}
