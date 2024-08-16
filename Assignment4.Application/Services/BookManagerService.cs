using Assignment4.Application.Interfaces;
using Assignment4.Domain.Entities;
using Assignment4.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Application.Services
{
    public class BookManagerService:IBookManagerService
    {
        private readonly IConfiguration _configuration;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookManagerRepository _bookManagerRepository;

        public BookManagerService(IConfiguration configuration, IBookRepository bookRepository, IUserRepository userRepository, IBookManagerRepository bookManagerRepository)
        {
            _configuration = configuration;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _bookManagerRepository = bookManagerRepository;
        }

        public async Task BorrowBook(int userId, int bookId)
        {
           
            var maxBooks = _configuration.GetValue<int>("LibrarySettings:MaxBooksPerUser");
            var PinjamDuration = _configuration.GetValue<int>("LibrarySettings:PinjamDuration");

            Book book = await _bookRepository.GetBookById(bookId); // Await the async method
            User user = await _userRepository.GetUserById(userId);

            int currentBorrowedBookCount = await _bookManagerRepository.GetBorrowedBooksCountByUser(userId);

            // Check if the user has already borrowed the maximum number of books
            if (currentBorrowedBookCount >= maxBooks)
            {
                throw new InvalidOperationException("User has already borrowed the maximum number of books allowed.");
            }


            //Configure Tanggal Pinjam dan kembali
            DateOnly tanggalPinjam = DateOnly.FromDateTime(DateTime.Now);
            DateOnly tanggalKembali = tanggalPinjam.AddDays(PinjamDuration);

            var borrowBook = new BookManager
            {
                UserId = userId,
                BookId = bookId,
                TanggalPinjam = tanggalPinjam,
                TanggalKembali = tanggalKembali
            };
            await _bookManagerRepository.AddBorrowRecord(borrowBook);   
        }

        public async Task ReturnBook(int userId, int bookId)
        {
            // Fetch the borrow record for the given user and book
            var borrowRecord = _bookManagerRepository.GetBorrowRecord(userId, bookId);
            if (borrowRecord == null) throw new Exception("Borrow record not found");

            var book = _bookRepository.GetBookById(bookId);

            _bookManagerRepository.DeleteBorrowRecord(borrowRecord);
        }
    }
}
