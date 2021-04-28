using bookbookiev11.Data;
using bookbookiev11.Interface;
using bookbookiev11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookbookiev11.Repository
{
    public class _BookRepository : IBook
    {
        private readonly ApplicationDbContext _Context;
        public _BookRepository(ApplicationDbContext Context)
        {
            Context = _Context;
        }

        public IEnumerable<BookModel> books { get; set; }
        public IEnumerable<BookModel> featured => _Context.BookModel.Where(p => p.isFeatured);

        IEnumerable<BookModel> IBook.featured { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public BookModel GetBookById(int bookId) =>  _Context.BookModel.FirstOrDefault(p => p.Id == bookId);
        
    }
}
