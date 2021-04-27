using bookbookiev11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookbookiev11.Interface
{
    public interface IBook
    {
        IEnumerable<BookModel> books { get; set; }

        IEnumerable<BookModel> featured { get; set; }

        BookModel GetBookById(int bookId);
    }
}
