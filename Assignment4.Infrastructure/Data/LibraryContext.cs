using Assignment4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Infrastructure.Data
{
    public class LibraryContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookManager> BookManagers { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookManager>()
                .HasOne(bm => bm.Book)
                .WithMany()
                .HasForeignKey(lb => lb.BookId);

            modelBuilder.Entity<BookManager>()
                .HasOne(bm => bm.User)
                .WithMany()
                .HasForeignKey(bm => bm.UserId);
        }
    }
}
