using bookbookiev11.Data;
using bookbookiev11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookbookiev11.Repsitory
{
    public class BookRepository
    {
        private readonly ApplicationDbContext _Context;
        public BookRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        
        
        
       
        public List<BookModel> GetBookTitle(String title)
        {
            return DataSource().Where(x => x.title.Contains(title)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {


            };
        }
    }
}
