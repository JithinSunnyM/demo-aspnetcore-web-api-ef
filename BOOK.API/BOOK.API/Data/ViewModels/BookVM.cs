using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOK.API.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }
    }
}
