using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Application.Interfaces
{
    public interface IBookManagerService
    {
        Task BorrowBook(int userId, int bookId);
        Task ReturnBook(int userId, int bookId);
    }
}
