using BOOK.API.Data.Services;
using BOOK.API.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _bookService;
        public BooksController(BooksService booksService)
        {
            _bookService = booksService;
        }

        [HttpGet("read")]
        public IActionResult GetAllBooks()
        {
            var allBooks =_bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("read/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("create")]
        public IActionResult AddBook(BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }
    }
}
