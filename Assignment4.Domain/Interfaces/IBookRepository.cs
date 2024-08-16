using Assignment4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
