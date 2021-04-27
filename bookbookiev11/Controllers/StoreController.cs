using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bookbookiev11.Data;
using bookbookiev11.Models;

namespace bookbookiev11.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // GET: Store
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookModel.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            ViewData["BookSearch"] = search;

            var searchQuery = from x in _context.BookModel select x;
            if (!string.IsNullOrEmpty(search))
            {
                searchQuery = searchQuery.Where(x => x.title.Contains(search) || x.author.Contains(search));
            }
            return View(await searchQuery.AsNoTracking().ToListAsync());
        }

        
        // GET: Store/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }
        public IActionResult Featured()
        {
            return View(_context.BookModel.Where(x => x.isFeatured).ToList());
        }

        public IActionResult NewRelease()
        {
            return View(_context.BookModel.Where(x => x.isNewRelease).ToList());
        }
    }
}
