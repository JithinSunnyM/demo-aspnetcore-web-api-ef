using BOOK.API.Data.Models;
using BOOK.API.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOK.API.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                CreatedDate = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }

        //Clean code - GetAllBooks()
        //public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            return book;
        }

        //Clean code - GetBookById
        //public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Author = book.Author;
                _book.Description = book.Description;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
